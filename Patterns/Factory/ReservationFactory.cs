using System;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Patterns.Factory
{
    // Factory class for creating Reservation objects based on room type
    public static class ReservationFactory
    {
        // Factory method to create a reservation with predefined base prices
        public static Reservation CreateReservation(string id, string guestName, string type, int nights)
        {
            // Create a new base reservation object
            var reservation = new Reservation
            {
                // Set the basic properties
                Id = id,
                GuestName = guestName,
                RoomType = type,
                Nights = nights,
                Status = "Pendiente"
            };

            // Set the base price depending on the room type
            switch (reservation.RoomType)
            {
                // Simple room: $50/night
                case "Simple":
                    reservation.BasePrice = 50m;
                    break;
                // Double room: $90/night
                case "Doble":
                    reservation.BasePrice = 90m;
                    break;
                // Suite room: $200/night
                case "Suite":
                    reservation.BasePrice = 200m;
                    break;
                // Throw an exception if the room type is invalid
                default:
                    throw new ArgumentException($"Tipo de habitación desconocido: {type}");
            }

            // Return the constructed reservation
            return reservation;
        }
    }
}
