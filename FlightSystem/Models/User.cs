namespace FlightBookingSystemAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PassportNumber { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public required ICollection<MasterBooking> MasterBookings { get; set; }
    }
}
