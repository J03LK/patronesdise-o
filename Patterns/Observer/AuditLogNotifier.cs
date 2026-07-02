using System;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Patterns.Observer
{
    // Observador responsable de registrar los eventos del sistema
    public class AuditLogNotifier : IReservationObserver
    {
        // Método que se activa con los cambios de estado de la reserva
        public void Update(Reservation reservation)
        {
            // Obtener la fecha y hora actual
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // Registrar la actualización de la reserva en español
            Console.WriteLine($"[AuditLogNotifier] [{timestamp}] Registro de auditoría: Reserva {reservation.Id} actualizada al estado '{reservation.Status}'.");
        }
    }
}
