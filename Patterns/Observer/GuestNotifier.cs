using System;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Patterns.Observer
{
    // Observador responsable de notificar al huésped
    public class GuestNotifier : IReservationObserver
    {
        // Método que se activa con los cambios de estado de la reserva
        public void Update(Reservation reservation)
        {
            // Mostrar un mensaje en la consola para el huésped
            Console.WriteLine($"[GuestNotifier] Hola {reservation.GuestName}, el estado de tu reserva {reservation.Id} ahora es: {reservation.Status}.");
        }
    }
}
