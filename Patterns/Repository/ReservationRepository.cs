using System.Collections.Generic;
using System.Linq;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Patterns.Repository
{
    // Clase repositorio para manejar el almacenamiento en memoria de las reservas
    public class ReservationRepository : IReservationRepository
    {
        // Lista en memoria para almacenar las reservas
        private readonly List<Reservation> _reservations = new List<Reservation>();

        // Guarda una nueva reserva en la lista
        public void Save(Reservation reservation)
        {
            // Agregar la reserva a la lista en memoria
            _reservations.Add(reservation);
        }

        // Recupera una reserva por su identificador único
        public Reservation? GetById(string id)
        {
            // Buscar y retornar la primera reserva que coincida con el id, o null
            return _reservations.FirstOrDefault(r => r.Id == id);
        }

        // Retorna todas las reservas almacenadas actualmente
        public IEnumerable<Reservation> GetAll()
        {
            // Retornar la lista de reservas
            return _reservations;
        }

        // Actualiza el estado de una reserva existente
        public void UpdateStatus(string id, string newStatus)
        {
            // Buscar la reserva por su id
            var reservation = GetById(id);
            // Si la reserva existe
            if (reservation != null)
            {
                // Actualizar su estado, esto activará los observadores
                reservation.Status = newStatus;
            }
        }
    }
}
