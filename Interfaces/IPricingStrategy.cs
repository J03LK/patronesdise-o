namespace HotelReservationSystem.Interfaces
{
    // Interfaz para el patrón Strategy que define cómo calcular el precio final
    public interface IPricingStrategy
    {
        // Calcula el precio final basado en el precio base y la cantidad de noches
        decimal CalculatePrice(decimal basePrice, int nights);
    }
}
