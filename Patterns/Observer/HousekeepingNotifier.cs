using System;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Patterns.Observer
{
    // Observer responsible for notifying housekeeping staff
    public class HousekeepingNotifier : IReservationObserver
    {
        // Method triggered on reservation state changes
        public void Update(Reservation reservation)
        {
            // Display a message in Spanish to the console for housekeeping
            Console.WriteLine($"[HousekeepingNotifier] Atención Limpieza: La habitación tipo '{reservation.RoomType}' de la reserva {reservation.Id} cambió a estado: {reservation.Status}.");
        }
    }
}
