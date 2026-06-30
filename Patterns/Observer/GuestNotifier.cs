using System;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Patterns.Observer
{
    // Observer responsible for notifying the guest
    public class GuestNotifier : IReservationObserver
    {
        // Method triggered on reservation state changes
        public void Update(Reservation reservation)
        {
            // Display a message in Spanish to the console
            Console.WriteLine($"[GuestNotifier] Hola {reservation.GuestName}, el estado de tu reserva {reservation.Id} ahora es: {reservation.Status}.");
        }
    }
}
