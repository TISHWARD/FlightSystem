namespace FlightBookingSystemAPI.Models
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetFlightsAsync();
        Task<Flight> GetFlightByIdAsync(int flightId);
        Task<Flight> AddFlightAsync(Flight flight);
        Task<Flight> UpdateFlightAsync(Flight flight);
        Task<bool> DeleteFlightAsync(int flightId);
    }
}
