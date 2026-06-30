using System.Collections.Generic;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Models;
using HotelReservationSystem.Patterns.Factory;

namespace HotelReservationSystem.Patterns
{
    // Service to orchestrate reservations, decoupled from concrete repository
    public class ReservationService
    {
        // Reference to the repository interface
        private readonly IReservationRepository _repository;
        
        // List of global observers to attach to new reservations
        private readonly List<IReservationObserver> _globalObservers;

        // Constructor injecting the repository dependency
        public ReservationService(IReservationRepository repository)
        {
            // Assign the injected repository
            _repository = repository;
            // Initialize the list of global observers
            _globalObservers = new List<IReservationObserver>();
        }

        // Subscribes a global observer to the service
        public void SubscribeObserver(IReservationObserver observer)
        {
            // Add the observer to the list
            _globalObservers.Add(observer);
        }

        // Unsubscribes a global observer from the service
        public void UnsubscribeObserver(IReservationObserver observer)
        {
            // Remove the observer from the list
            _globalObservers.Remove(observer);
            
            // Also detach from all existing reservations in the repository
            foreach (var reservation in _repository.GetAll())
            {
                // Detach the observer
                reservation.Detach(observer);
            }
        }

        // Creates a new reservation, applies pricing, attaches observers and saves it
        public Reservation CreateReservation(string id, string guestName, string roomType, int nights, IPricingStrategy pricingStrategy)
        {
            // Create the reservation using the Factory Method
            var reservation = ReservationFactory.CreateReservation(id, guestName, roomType, nights);
            
            // Calculate the total price using the provided Strategy
            reservation.TotalPrice = pricingStrategy.CalculatePrice(reservation.BasePrice, nights);

            // Attach all subscribed global observers to this new reservation
            foreach (var observer in _globalObservers)
            {
                // Attach the observer
                reservation.Attach(observer);
            }

            // Save the reservation in the Repository
            _repository.Save(reservation);

            // Return the created reservation
            return reservation;
        }

        // Updates the status of an existing reservation
        public void UpdateReservationStatus(string id, string newStatus)
        {
            // Delegate the update to the repository
            _repository.UpdateStatus(id, newStatus);
        }

        // Retrieves all reservations
        public IEnumerable<Reservation> GetAllReservations()
        {
            // Return from the repository
            return _repository.GetAll();
        }
    }
}
