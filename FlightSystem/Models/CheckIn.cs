namespace FlightBookingSystemAPI.Models
{
    public class CheckIn
    {
        public int CheckinId { get; set; }

        // Foreign Key Property: Make sure it matches the type of the primary key in MasterBooking
        public int MasterBookingId { get; set; }  // This should be an int or long, matching MasterBooking's primary key

        public DateTime CheckinDate { get; set; }
        public string CheckinStatus { get; set; }

        // Navigation property
        public MasterBooking MasterBooking { get; set; }
    }

}
