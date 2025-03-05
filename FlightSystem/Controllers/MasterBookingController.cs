//using FlightBookingSystemAPI.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace FlightBookingSystemAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MasterBookingController : ControllerBase
//    {
//    }
//}
using FlightBookingSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterBookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MasterBookingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterBooking>>> GetMasterBookings()
        {
            return await _context.MasterBookings.Include(m => m.User).Include(m => m.Flight).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<MasterBooking>> CreateMasterBooking(MasterBooking masterBooking)
        {
            _context.MasterBookings.Add(masterBooking);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMasterBookings), new { id = masterBooking.BookingId }, masterBooking);
        }
    }
}
