using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBookingSystemAPI.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int BookingId { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid payment date format.")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2100", ErrorMessage = "Payment date must be between 01/01/1900 and 12/31/2100.")]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount paid must be a positive value.")]
        public decimal AmountPaid { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Payment status cannot be longer than 20 characters.")]
        public string PaymentStatus { get; set; }

        public MasterBooking MasterBooking { get; set; }
    }
}
