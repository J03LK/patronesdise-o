using System.Collections.Generic;
using System.Linq;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Patterns.Repository
{
    // Repository class to manage in-memory storage of reservations
    public class ReservationRepository : IReservationRepository
    {
        // In-memory list to store reservations
        private readonly List<Reservation> _reservations = new List<Reservation>();

        // Saves a new reservation to the list
        public void Save(Reservation reservation)
        {
            // Add the reservation to the in-memory list
            _reservations.Add(reservation);
        }

        // Retrieves a reservation by its unique identifier
        public Reservation? GetById(string id)
        {
            // Find and return the first reservation matching the id, or null
            return _reservations.FirstOrDefault(r => r.Id == id);
        }

        // Returns all reservations currently stored
        public IEnumerable<Reservation> GetAll()
        {
            // Return the list of reservations
            return _reservations;
        }

        // Updates the status of an existing reservation
        public void UpdateStatus(string id, string newStatus)
        {
            // Find the reservation by id
            var reservation = GetById(id);
            // If the reservation exists
            if (reservation != null)
            {
                // Update its status, this will trigger the observers
                reservation.Status = newStatus;
            }
        }
    }
}
