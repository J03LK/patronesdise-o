using System.Collections.Generic;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Models;
using HotelReservationSystem.Patterns.Factory;

namespace HotelReservationSystem.Patterns
{
    // Servicio para orquestar reservas, desacoplado del repositorio concreto
    public class ReservationService
    {
        // Referencia a la interfaz del repositorio
        private readonly IReservationRepository _repository;
        
        // Lista de observadores globales para adjuntar a nuevas reservas
        private readonly List<IReservationObserver> _globalObservers;

        // Constructor que inyecta la dependencia del repositorio
        public ReservationService(IReservationRepository repository)
        {
            // Asignar el repositorio inyectado
            _repository = repository;
            // Inicializar la lista de observadores globales
            _globalObservers = new List<IReservationObserver>();
        }

        // Suscribe un observador global al servicio
        public void SubscribeObserver(IReservationObserver observer)
        {
            // Agregar el observador a la lista
            _globalObservers.Add(observer);
        }

        // Desuscribe un observador global del servicio
        public void UnsubscribeObserver(IReservationObserver observer)
        {
            // Remover el observador de la lista
            _globalObservers.Remove(observer);
            
            // También separarlo de todas las reservas existentes en el repositorio
            foreach (var reservation in _repository.GetAll())
            {
                // Separar el observador
                reservation.Detach(observer);
            }
        }

        // Crea una nueva reserva, aplica el precio, adjunta observadores y la guarda
        public Reservation CreateReservation(string id, string guestName, string roomType, int nights, IPricingStrategy pricingStrategy)
        {
            // Crear la reserva utilizando el Factory Method
            var reservation = ReservationFactory.CreateReservation(id, guestName, roomType, nights);
            
            // Calcular el precio total utilizando el Strategy proporcionado
            reservation.TotalPrice = pricingStrategy.CalculatePrice(reservation.BasePrice, nights);

            // Adjuntar todos los observadores globales suscritos a esta nueva reserva
            foreach (var observer in _globalObservers)
            {
                // Adjuntar el observador
                reservation.Attach(observer);
            }

            // Guardar la reserva en el Repository
            _repository.Save(reservation);

            // Retornar la reserva creada
            return reservation;
        }

        // Actualiza el estado de una reserva existente
        public void UpdateReservationStatus(string id, string newStatus)
        {
            // Delegar la actualización al repositorio
            _repository.UpdateStatus(id, newStatus);
        }

        // Recupera todas las reservas
        public IEnumerable<Reservation> GetAllReservations()
        {
            // Retornar desde el repositorio
            return _repository.GetAll();
        }
    }
}
