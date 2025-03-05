namespace FlightBookingSystemAPI.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentStatus { get; set; }

        public required MasterBooking MasterBooking { get; set; }
    }
}
