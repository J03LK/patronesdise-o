using HotelReservationSystem.Models;

namespace HotelReservationSystem.Interfaces
{
    // Interfaz para el patrón Observer para recibir actualizaciones de las reservas
    public interface IReservationObserver
    {
        // Método llamado cuando cambia el estado de una reserva
        void Update(Reservation reservation);
    }
}
