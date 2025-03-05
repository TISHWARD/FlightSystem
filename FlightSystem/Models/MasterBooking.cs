using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystemAPI.Models
{
    public class MasterBooking
    {
        [Key]
        public int BookingId { get; set; }  // Primary key
        //public int BookingId { get; set; }
        public int UserId { get; set; }
        public int FlightId { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string SeatClass { get; set; }
        public required string SpecialRequests { get; set; }
        public string BaggageAllowance { get; set; }
        public int TotalBagsChecked { get; set; }
        public int TotalPassengers { get; set; }
        public string FlightType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User User { get; set; }
        public Flight Flight { get; set; }
        public CheckIn CheckIn { get; set; }
        public ICollection<Payment> Payments { get; set; }
        //public CheckIn CheckIn { get; set; }  // Navigation property

    }
}
