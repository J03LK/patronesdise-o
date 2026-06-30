using HotelReservationSystem.Models;

namespace HotelReservationSystem.Interfaces
{
    // Interface for the Observer pattern to receive reservation updates
    public interface IReservationObserver
    {
        // Method called when a reservation state changes
        void Update(Reservation reservation);
    }
}
