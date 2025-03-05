namespace FlightBookingSystemAPI.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }

        public ICollection<MasterBooking> MasterBookings { get; set; }
    }
}
