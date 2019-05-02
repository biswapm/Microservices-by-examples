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
    public class RoomTypesController : ControllerBase
    {
        private readonly HotelsContext _context;

        public RoomTypesController(HotelsContext context)
        {
            _context = context;
        }

        // GET: api/RoomTypes
        [HttpGet]
        public IEnumerable<RoomTypes> GetRoomTypes()
        {
            return _context.RoomTypes;
        }

        // GET: api/RoomTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomTypes([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomTypes = await _context.RoomTypes.FindAsync(id);

            if (roomTypes == null)
            {
                return NotFound();
            }

            return Ok(roomTypes);
        }

        // PUT: api/RoomTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomTypes([FromRoute] string id, [FromBody] RoomTypes roomTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTypesExists(id))
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

        // POST: api/RoomTypes
        [HttpPost]
        public async Task<IActionResult> PostRoomTypes([FromBody] RoomTypes roomTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RoomTypes.Add(roomTypes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomTypesExists(roomTypes.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoomTypes", new { id = roomTypes.Id }, roomTypes);
        }

        // DELETE: api/RoomTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomTypes([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomTypes = await _context.RoomTypes.FindAsync(id);
            if (roomTypes == null)
            {
                return NotFound();
            }

            _context.RoomTypes.Remove(roomTypes);
            await _context.SaveChangesAsync();

            return Ok(roomTypes);
        }

        private bool RoomTypesExists(string id)
        {
            return _context.RoomTypes.Any(e => e.Id == id);
        }
    }
}