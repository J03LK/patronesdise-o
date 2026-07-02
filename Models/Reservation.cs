using System.Collections.Generic;
using HotelReservationSystem.Interfaces;

namespace HotelReservationSystem.Models
{
    // Clase que representa una reserva de hotel, actúa como Subject en el patrón Observer
    public class Reservation
    {
        // Identificador único para la reserva
        public string Id { get; set; } = string.Empty;
        
        // Nombre del huésped que hace la reserva
        public string GuestName { get; set; } = string.Empty;
        
        // Tipo de habitación reservada (simple, doble, suite)
        public string RoomType { get; set; } = string.Empty;
        
        // Precio base de la habitación por noche
        public decimal BasePrice { get; set; }
        
        // Precio total calculado utilizando la estrategia de precios
        public decimal TotalPrice { get; set; }
        
        // Número de noches de estadía
        public int Nights { get; set; }

        // Campo de respaldo para la propiedad Status
        private string _status = "Pending";
        
        // Estado actual de la reserva (Pending, Confirmed, CheckedIn, CheckedOut, Cancelled)
        public string Status 
        { 
            get { return _status; } 
            set 
            {
                // Solo actualizar y notificar si el estado realmente cambia
                if (_status != value)
                {
                    // Actualizar el estado interno
                    _status = value;
                    // Notificar automáticamente a los observadores sobre el cambio de estado
                    NotifyObservers();
                }
            } 
        }

        // Lista de observadores suscritos
        private List<IReservationObserver> _observers = new List<IReservationObserver>();

        // Adjunta un nuevo observador a esta reserva
        public void Attach(IReservationObserver observer)
        {
            // Agregar el observador a la lista
            _observers.Add(observer);
        }

        // Separa un observador existente de esta reserva
        public void Detach(IReservationObserver observer)
        {
            // Remover el observador de la lista
            _observers.Remove(observer);
        }

        // Notifica a todos los observadores suscritos sobre el cambio de estado
        private void NotifyObservers()
        {
            // Iterar a través de cada observador y llamar a su método Update
            foreach (var observer in _observers)
            {
                // Pasar el objeto de reserva actual al observador
                observer.Update(this);
            }
        }
    }
}
