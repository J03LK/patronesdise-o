using HotelReservationSystem.Interfaces;

namespace HotelReservationSystem.Patterns.Strategy
{
    // Pricing strategy for holiday season
    public class HolidaySeasonPricing : IPricingStrategy
    {
        // Calculates price applying a 100% surcharge and fixed $30 extra per night
        public decimal CalculatePrice(decimal basePrice, int nights)
        {
            // Base price x 2.0 + $30 per services, all multiplied by number of nights
            // Wait, the document says: "Precio base x 2.0 + $30 por servicios especiales".
            // Does the $30 apply per night or total? Usually per night, but let's read carefully:
            // "El cálculo se obtiene multiplicando el precio base de la habitación por el factor de la estrategia y por el número de noches."
            // "Precio base x 2.0 + $30 por servicios especiales". Let's apply it per night to be safe and match the formula.
            return ((basePrice * 2.0m) + 30m) * nights;
        }
    }
}
