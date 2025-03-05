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
        private readonly IMasterBookingRepository _masterBookingRepository;

        public MasterBookingController(IMasterBookingRepository masterBookingRepository)
        {
            _masterBookingRepository = masterBookingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterBooking>>> GetMasterBookings()
        {
            var bookings = await _masterBookingRepository.GetMasterBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MasterBooking>> GetMasterBooking(int id)
        {
            var booking = await _masterBookingRepository.GetMasterBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public async Task<ActionResult<MasterBooking>> CreateMasterBooking(MasterBooking masterBooking)
        {
            var createdBooking = await _masterBookingRepository.AddMasterBookingAsync(masterBooking);
            return CreatedAtAction(nameof(GetMasterBooking), new { id = createdBooking.BookingId }, createdBooking);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MasterBooking>> UpdateMasterBooking(int id, MasterBooking masterBooking)
        {
            if (id != masterBooking.BookingId)
            {
                return BadRequest();
            }

            var updatedBooking = await _masterBookingRepository.UpdateMasterBookingAsync(masterBooking);
            return Ok(updatedBooking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterBooking(int id)
        {
            var success = await _masterBookingRepository.DeleteMasterBookingAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
