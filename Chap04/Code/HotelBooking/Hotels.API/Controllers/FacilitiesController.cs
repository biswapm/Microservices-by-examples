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
    public class FacilitiesController : ControllerBase
    {
        private readonly HotelsContext _context;

        public FacilitiesController(HotelsContext context)
        {
            _context = context;
        }

        // GET: api/Facilities
        [HttpGet]
        public IEnumerable<Facilities> GetFacilities()
        {
            return _context.Facilities;
        }

        // GET: api/Facilities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacilities([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var facilities = await _context.Facilities.FindAsync(id);

            if (facilities == null)
            {
                return NotFound();
            }

            return Ok(facilities);
        }

        // PUT: api/Facilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacilities([FromRoute] string id, [FromBody] Facilities facilities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facilities.Id)
            {
                return BadRequest();
            }

            _context.Entry(facilities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilitiesExists(id))
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

        // POST: api/Facilities
        [HttpPost]
        public async Task<IActionResult> PostFacilities([FromBody] Facilities facilities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Facilities.Add(facilities);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FacilitiesExists(facilities.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFacilities", new { id = facilities.Id }, facilities);
        }

        // DELETE: api/Facilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacilities([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var facilities = await _context.Facilities.FindAsync(id);
            if (facilities == null)
            {
                return NotFound();
            }

            _context.Facilities.Remove(facilities);
            await _context.SaveChangesAsync();

            return Ok(facilities);
        }

        private bool FacilitiesExists(string id)
        {
            return _context.Facilities.Any(e => e.Id == id);
        }
    }
}