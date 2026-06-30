using System.Collections.Generic;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Interfaces
{
    // Interface for the Repository pattern to manage reservations storage
    public interface IReservationRepository
    {
        // Saves a new reservation in the repository
        void Save(Reservation reservation);

        // Finds a reservation by its id, returns null if not found
        Reservation? GetById(string id);

        // Returns all stored reservations
        IEnumerable<Reservation> GetAll();

        // Updates the status of an existing reservation
        void UpdateStatus(string id, string newStatus);
    }
}
