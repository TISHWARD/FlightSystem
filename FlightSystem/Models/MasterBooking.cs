using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystemAPI.Models
{
    public class MasterBooking
    {
        [Key]
        public int BookingId { get; set; }  // ReferenceNumber

        [Required]
        public int UserId { get; set; }

        [Required]
        public int FlightId { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid booking date format.")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2100", ErrorMessage = "Booking date must be between 01/01/1900 and 12/31/2100.")]
        public DateTime BookingDate { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Booking status cannot be longer than 20 characters.")]
        public string BookingStatus { get; set; }

  
        //[Required]
        //[StringLength(5, ErrorMessage = "Currency code must be 3 characters.")]
        //public string Currency { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Payment status cannot be longer than 20 characters.")]
        public string PaymentStatus { get; set; }

        //[StringLength(50, ErrorMessage = "Payment method cannot be longer than 50 characters.")]
        //public string PaymentMethod { get; set; }

        [StringLength(20, ErrorMessage = "Seat class cannot be longer than 20 characters.")]
        public string SeatClass { get; set; }

     

        //[StringLength(20, ErrorMessage = "Baggage allowance cannot be longer than 20 characters.")]
        //public string BaggageAllowance { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Total bags checked cannot be negative.")]
        public int TotalBagsChecked { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Total passengers must be at least 1.")]
        public int TotalPassengers { get; set; }

        [StringLength(20, ErrorMessage = "Flight type cannot be longer than 20 characters.")]
        public string FlightType { get; set; }

    

        public User User { get; set; }
        public Flight Flight { get; set; }
        public CheckIn CheckIn { get; set; }

        public ICollection<Payment> Payments { get; set; }

    }
}
