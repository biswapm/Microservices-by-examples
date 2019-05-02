using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using System.Transactions;
using Booking.API.Services;

namespace Booking.API.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly HotelBookingsContext _context;
        private readonly IIdentityService _identitySvc;


        public BookingsController(HotelBookingsContext context, IIdentityService identityService)
        {
            _context = context;
            _identitySvc = identityService;
        }

        // GET: api/Bookings
        [HttpGet]
        public IEnumerable<BookingsInfo> GetBookings()
        {
            return _context.BookingsInfo;
        }
        [HttpGet]
        public IEnumerable<BookingsInfo> GetUsersBookings([FromRoute]string customerID)
        {
            //var userId = _identitySvc.GetUserIdentity();
            var bookings = _context.BookingsInfo.Where(p => p.CustomerId.ToString() == customerID);

            if (bookings == null)
            {
                throw new ArgumentNullException("No Bookings for this Customer");
            }
            return bookings;

        }
        [HttpGet]
        public IEnumerable<BookingsInfo> GetBookingsHotel([FromRoute]string hotelName)
        {
            //var userId = _identitySvc.GetUserIdentity();
            var bookings = _context.BookingsInfo.Where(p => p.HotelName == hotelName);

            if (bookings == null)
            {
                throw new ArgumentNullException("No Bookings for this Hotel");
            }
            return bookings;

        }
        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookings([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var bookings = await _context.BookingsInfo.FindAsync(id);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }


        // POST: api/Bookings
        [HttpPost]
        public async Task<IActionResult> PostBookings([FromBody] BookingsInfo bookings)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BookingsInfo.Add(bookings);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingsExists(bookings.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookings", new { id = bookings.Id }, bookings);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookings([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookings = await _context.BookingsInfo.FindAsync(id);
            if (bookings == null)
            {
                return NotFound();
            }

            _context.BookingsInfo.Remove(bookings);
            await _context.SaveChangesAsync();

            return Ok(bookings);
        }

        private bool BookingsExists(string id)
        {
            return _context.BookingsInfo.Any(e => e.Id == id);
        }
    }
}