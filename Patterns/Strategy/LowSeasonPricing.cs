using HotelReservationSystem.Interfaces;

namespace HotelReservationSystem.Patterns.Strategy
{
    // Estrategia de precios para temporada baja
    public class LowSeasonPricing : IPricingStrategy
    {
        // Calcula el precio aplicando un descuento del 20%
        public decimal CalculatePrice(decimal basePrice, int nights)
        {
            // Precio base x 0.8 (20% de descuento) x cantidad de noches
            return (basePrice * 0.8m) * nights;
        }
    }
}
