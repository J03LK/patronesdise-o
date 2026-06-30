using System.Collections.Generic;
using HotelReservationSystem.Interfaces;

namespace HotelReservationSystem.Models
{
    // Class representing a hotel reservation, acts as the Subject in the Observer pattern
    public class Reservation
    {
        // Unique identifier for the reservation
        public string Id { get; set; } = string.Empty;
        
        // Name of the guest making the reservation
        public string GuestName { get; set; } = string.Empty;
        
        // Type of room booked (simple, double, suite)
        public string RoomType { get; set; } = string.Empty;
        
        // Base price of the room per night
        public decimal BasePrice { get; set; }
        
        // Total price calculated using the pricing strategy
        public decimal TotalPrice { get; set; }
        
        // Number of nights for the stay
        public int Nights { get; set; }

        // Backing field for the Status property
        private string _status = "Pending";
        
        // Current status of the reservation (Pending, Confirmed, CheckedIn, CheckedOut, Cancelled)
        public string Status 
        { 
            get { return _status; } 
            set 
            {
                // Only update and notify if the status actually changes
                if (_status != value)
                {
                    // Update the internal status
                    _status = value;
                    // Automatically notify observers of the state change
                    NotifyObservers();
                }
            } 
        }

        // List of subscribed observers
        private List<IReservationObserver> _observers = new List<IReservationObserver>();

        // Attaches a new observer to this reservation
        public void Attach(IReservationObserver observer)
        {
            // Add observer to the list
            _observers.Add(observer);
        }

        // Detaches an existing observer from this reservation
        public void Detach(IReservationObserver observer)
        {
            // Remove observer from the list
            _observers.Remove(observer);
        }

        // Notifies all subscribed observers about the state change
        private void NotifyObservers()
        {
            // Loop through each observer and call its Update method
            foreach (var observer in _observers)
            {
                // Pass the current reservation object to the observer
                observer.Update(this);
            }
        }
    }
}
