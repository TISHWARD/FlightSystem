namespace FlightBookingSystemAPI.Models
{
    public interface IMasterBookingRepository
    {
        Task<IEnumerable<MasterBooking>> GetMasterBookingsAsync();
        Task<MasterBooking> GetMasterBookingByIdAsync(int bookingId);
        Task<MasterBooking> AddMasterBookingAsync(MasterBooking masterBooking);
        Task<MasterBooking> UpdateMasterBookingAsync(MasterBooking masterBooking);
        Task<bool> DeleteMasterBookingAsync(int bookingId);
    }
}
