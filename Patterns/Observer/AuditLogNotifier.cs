using System;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Patterns.Observer
{
    // Observer responsible for logging system events
    public class AuditLogNotifier : IReservationObserver
    {
        // Method triggered on reservation state changes
        public void Update(Reservation reservation)
        {
            // Get current timestamp
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // Log the reservation update in Spanish
            Console.WriteLine($"[AuditLogNotifier] [{timestamp}] Registro de auditoría: Reserva {reservation.Id} actualizada al estado '{reservation.Status}'.");
        }
    }
}
