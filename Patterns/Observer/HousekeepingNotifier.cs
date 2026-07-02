using System;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Patterns.Observer
{
    // Observador responsable de notificar al personal de limpieza
    public class HousekeepingNotifier : IReservationObserver
    {
        // Método que se activa con los cambios de estado de la reserva
        public void Update(Reservation reservation)
        {
            // Mostrar un mensaje en la consola para limpieza
            Console.WriteLine($"[HousekeepingNotifier] Atención Limpieza: La habitación tipo '{reservation.RoomType}' de la reserva {reservation.Id} cambió a estado: {reservation.Status}.");
        }
    }
}
