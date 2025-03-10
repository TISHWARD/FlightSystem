using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystemAPI.Models
{
    public class CheckIn
    {
        internal object MasterBookingId;

        public int CheckinId { get; set; }

        [Required]
        public int BookingId { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid check-in date format.")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2100", ErrorMessage = "Check-in date must be between 01/01/1900 and 12/31/2100.")]
        public DateTime CheckinDate { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Check-in status cannot be longer than 20 characters.")]
        public string CheckinStatus { get; set; }

        public MasterBooking MasterBooking { get; set; }
    }

}
