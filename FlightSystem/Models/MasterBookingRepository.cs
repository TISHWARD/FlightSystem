using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystemAPI.Models
{
    public class MasterBookingRepository : IMasterBookingRepository
    {
        private readonly AppDbContext _context;

        public MasterBookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MasterBooking>> GetMasterBookingsAsync()
        {
            return await _context.MasterBookings.Include(m => m.User).Include(m => m.Flight).ToListAsync();
        }

        public async Task<MasterBooking> GetMasterBookingByIdAsync(int bookingId)
        {
            return await _context.MasterBookings.Include(m => m.User).Include(m => m.Flight)
                .FirstOrDefaultAsync(m => m.BookingId == bookingId);
        }

        public async Task<MasterBooking> AddMasterBookingAsync(MasterBooking masterBooking)
        {
            _context.MasterBookings.Add(masterBooking);
            await _context.SaveChangesAsync();
            return masterBooking;
        }

        public async Task<MasterBooking> UpdateMasterBookingAsync(MasterBooking masterBooking)
        {
            _context.MasterBookings.Update(masterBooking);
            await _context.SaveChangesAsync();
            return masterBooking;
        }

        public async Task<bool> DeleteMasterBookingAsync(int bookingId)
        {
            var masterBooking = await _context.MasterBookings.FindAsync(bookingId);
            if (masterBooking == null) return false;

            _context.MasterBookings.Remove(masterBooking);
            await _context.SaveChangesAsync();
            return true;
        }
    }


}
