using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystemAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public string Address { get; set; }

        [StringLength(20, ErrorMessage = "Passport number cannot be longer than 20 characters.")]
        public string PassportNumber { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2100", ErrorMessage = "Date of birth must be between 01/01/1900 and 12/31/2100.")]
        public DateTime Dob { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Gender cannot be longer than 10 characters.")]
        public string Gender { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Nationality cannot be longer than 50 characters.")]
        public string Nationality { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<MasterBooking> MasterBookings { get; set; }
    }

}
