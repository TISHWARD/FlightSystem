using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBookingSystemAPI.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FlightId { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Flight number cannot be longer than 10 characters.")]
        public string FlightName { get; set; }

        [Required]
        public string DepartureAirport{ get; set; }

        [Required]
        public string ArrivalAirport { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid departure date format.")]
        public DateTime DepartureDate { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid arrival date format.")]
        public DateTime ArrivalDate { get; set; }

        public ICollection<MasterBooking> MasterBookings { get; set; }

    }
}
