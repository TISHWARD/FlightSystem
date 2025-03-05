using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystemAPI.Models
{

        public class CheckInRepository : ICheckInRepository
        {
            private readonly AppDbContext _context;

            public CheckInRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<CheckIn>> GetCheckInsAsync()
            {
                return await _context.CheckIns.Include(c => c.MasterBooking).ToListAsync();
            }

            public async Task<CheckIn> GetCheckInByIdAsync(int checkinId)
            {
                return await _context.CheckIns.Include(c => c.MasterBooking)
                                              .FirstOrDefaultAsync(c => c.CheckinId == checkinId);
            }

            public async Task<CheckIn> AddCheckInAsync(CheckIn checkIn)
            {
                _context.CheckIns.Add(checkIn);
                await _context.SaveChangesAsync();
                return checkIn;
            }

            public async Task<CheckIn> UpdateCheckInAsync(CheckIn checkIn)
            {
                _context.CheckIns.Update(checkIn);
                await _context.SaveChangesAsync();
                return checkIn;
            }

            public async Task<bool> DeleteCheckInAsync(int checkinId)
            {
                var checkIn = await _context.CheckIns.FindAsync(checkinId);
                if (checkIn == null) return false;

                _context.CheckIns.Remove(checkIn);
                await _context.SaveChangesAsync();
                return true;
            }
        

    }
}
