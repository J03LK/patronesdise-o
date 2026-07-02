using System;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Patterns.Factory
{
    // Clase Factory para crear objetos Reservation basados en el tipo de habitación
    public static class ReservationFactory
    {
        // Método de fábrica para crear una reserva con precios base predefinidos
        public static Reservation CreateReservation(string id, string guestName, string type, int nights)
        {
            // Crear un nuevo objeto de reserva base
            var reservation = new Reservation
            {
                // Configurar las propiedades básicas
                Id = id,
                GuestName = guestName,
                RoomType = type,
                Nights = nights,
                Status = "Pendiente"
            };

            // Establecer el precio base dependiendo del tipo de habitación
            switch (reservation.RoomType)
            {
                // Habitación simple: $50/noche
                case "Simple":
                    reservation.BasePrice = 50m;
                    break;
                // Habitación doble: $90/noche
                case "Doble":
                    reservation.BasePrice = 90m;
                    break;
                // Habitación suite: $200/noche
                case "Suite":
                    reservation.BasePrice = 200m;
                    break;
                // Lanzar una excepción si el tipo de habitación es inválido
                default:
                    throw new ArgumentException($"Tipo de habitación desconocido: {type}");
            }

            // Retornar la reserva construida
            return reservation;
        }
    }
}
