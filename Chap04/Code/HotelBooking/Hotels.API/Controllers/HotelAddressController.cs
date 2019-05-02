using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.API.Models;

namespace Hotels.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelAddressController : ControllerBase
    {
        private readonly HotelsContext _context;

        public HotelAddressController(HotelsContext context)
        {
            _context = context;
        }

        // GET: api/HotelAddress
        [HttpGet]
        public IEnumerable<HotelAddress> GetHotelAddress()
        {
            return _context.HotelAddress;
        }

        // GET: api/HotelAddress/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotelAddress = await _context.HotelAddress.FindAsync(id);

            if (hotelAddress == null)
            {
                return NotFound();
            }

            return Ok(hotelAddress);
        }

        // PUT: api/HotelAddress/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelAddress([FromRoute] int id, [FromBody] HotelAddress hotelAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotelAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelAddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HotelAddress
        [HttpPost]
        public async Task<IActionResult> PostHotelAddress([FromBody] HotelAddress hotelAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HotelAddress.Add(hotelAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelAddress", new { id = hotelAddress.Id }, hotelAddress);
        }

        // DELETE: api/HotelAddress/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotelAddress = await _context.HotelAddress.FindAsync(id);
            if (hotelAddress == null)
            {
                return NotFound();
            }

            _context.HotelAddress.Remove(hotelAddress);
            await _context.SaveChangesAsync();

            return Ok(hotelAddress);
        }

        private bool HotelAddressExists(int id)
        {
            return _context.HotelAddress.Any(e => e.Id == id);
        }
    }
}