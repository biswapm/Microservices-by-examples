using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.API.Models;
using Microsoft.AspNetCore.Cors;

namespace Hotels.API.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowMyOrigin")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly HotelsContext _context;

        public RoomsController(HotelsContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<Rooms> GetRooms()
        {
            return _context.Rooms;
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRooms([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms = await _context.Rooms.FindAsync(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        [HttpGet("GetRoomsByHotel/{id}")]
       // [Route("")]
        public IEnumerable<Rooms> GetRoomsByHotel([FromRoute] int id)
        {
           return _context.Rooms.Where(p => p.HotelId == id);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
		//[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> PutRooms([FromRoute] string id, [FromBody] Rooms rooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rooms.Id)
            {
                return BadRequest();
            }

            _context.Entry(rooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomsExists(id))
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

        // POST: api/Rooms
        [HttpPost]
		//[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> PostRooms([FromBody] Rooms rooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            rooms.Id = Guid.NewGuid().ToString();
            _context.Rooms.Add(rooms);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomsExists(rooms.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRooms", new { id = rooms.Id }, rooms);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
		//[Authorize(Policy = "AdminRole")]

		public async Task<IActionResult> DeleteRooms([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms = await _context.Rooms.FindAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(rooms);
            await _context.SaveChangesAsync();

            return Ok(rooms);
        }

        private bool RoomsExists(string id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}