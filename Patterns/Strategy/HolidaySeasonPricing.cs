using HotelReservationSystem.Interfaces;

namespace HotelReservationSystem.Patterns.Strategy
{
    // Estrategia de precios para temporada de feriado
    public class HolidaySeasonPricing : IPricingStrategy
    {
        // Calcula el precio aplicando un recargo del 100% y $30 extras por noche
        public decimal CalculatePrice(decimal basePrice, int nights)
        {
            // Precio base x 2.0 + $30 por servicios especiales, todo multiplicado por la cantidad de noches
            // Espera, el documento dice: "Precio base x 2.0 + $30 por servicios especiales".
            // ¿Los $30 aplican por noche o en total? Normalmente por noche, leamos con cuidado:
            // "El cálculo se obtiene multiplicando el precio base de la habitación por el factor de la estrategia y por el número de noches."
            // "Precio base x 2.0 + $30 por servicios especiales". Apliquémoslo por noche para estar seguros y coincidir con la fórmula.
            return ((basePrice * 2.0m) + 30m) * nights;
        }
    }
}
