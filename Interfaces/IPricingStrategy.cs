namespace HotelReservationSystem.Interfaces
{
    // Interface for the Strategy pattern defining how to calculate the final price
    public interface IPricingStrategy
    {
        // Calculates the final price based on the base price and number of nights
        decimal CalculatePrice(decimal basePrice, int nights);
    }
}
