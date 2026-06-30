using HotelReservationSystem.Interfaces;

namespace HotelReservationSystem.Patterns.Strategy
{
    // Pricing strategy for low season
    public class LowSeasonPricing : IPricingStrategy
    {
        // Calculates price applying a 20% discount
        public decimal CalculatePrice(decimal basePrice, int nights)
        {
            // Base price x 0.8 (20% discount) x number of nights
            return (basePrice * 0.8m) * nights;
        }
    }
}
