using HotelReservationSystem.Interfaces;

namespace HotelReservationSystem.Patterns.Strategy
{
    // Pricing strategy for high season
    public class HighSeasonPricing : IPricingStrategy
    {
        // Calculates price applying a 50% surcharge
        public decimal CalculatePrice(decimal basePrice, int nights)
        {
            // Base price x 1.5 (50% surcharge) x number of nights
            return (basePrice * 1.5m) * nights;
        }
    }
}
