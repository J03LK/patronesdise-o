using HotelReservationSystem.Interfaces;

namespace HotelReservationSystem.Patterns.Strategy
{
    // Estrategia de precios para temporada alta
    public class HighSeasonPricing : IPricingStrategy
    {
        // Calcula el precio aplicando un recargo del 50%
        public decimal CalculatePrice(decimal basePrice, int nights)
        {
            // Precio base x 1.5 (50% de recargo) x cantidad de noches
            return (basePrice * 1.5m) * nights;
        }
    }
}
