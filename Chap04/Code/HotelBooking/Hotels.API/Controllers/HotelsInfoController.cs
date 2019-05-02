using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Hotels.API.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("SiteCorsPolicy")]
    [ApiController]
    public class HotelsInfoController : ControllerBase
    {
        private readonly HotelsContext _context;

        public HotelsInfoController(HotelsContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<HotelsInfo> FindHotelsInCity(string city, DateTime startDate, DateTime endDate)
        {
            var hotelNames = from hotels in _context.HotelsInfo
                             join address in _context.HotelAddress on hotels.HotelId equals address.HotelId
                             join room in _context.Rooms on hotels.HotelId equals room.HotelId
                             where address.City.Equals(city) && room.Available == true
                             select hotels;
            return hotelNames;
        }


        //// GET: api/HotelsInfo/HotelsList
        //[HttpGet("HotelsList")]
        //public IEnumerable<HotelsInfo> GetHotelsInfo()
        //{
        //    return _context.HotelsInfo.ToList();
        //}

        // GET: api/HotelsInfo/HotelsList
        [HttpGet("HotelsList")]
        public IActionResult GetHotelsInfo()
        {
            var hotels = _context.HotelsInfo;
            return Ok(hotels);
        }


        // GET: api/HotelsInfo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelsInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotelsInfo = await _context.HotelsInfo.FindAsync(id);

            if (hotelsInfo == null)
            {
                return NotFound();
            }

            return Ok(hotelsInfo);
        }

        // PUT: api/HotelsInfo/5
        [HttpPut("{id}")]
        //[Authorize(Policy = "AdminRole")]
        public async Task<IActionResult> PutHotelsInfo([FromRoute] int id, [FromBody] HotelsInfo hotelsInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotelsInfo.HotelId)
            {
                return BadRequest();
            }

            _context.Entry(hotelsInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsInfoExists(id))
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

        // POST: api/HotelsInfo
        [HttpPost]
        //[Authorize(Policy = "AdminRole")]
        public async Task<IActionResult> PostHotelsInfo([FromBody] HotelsInfo hotelsInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HotelsInfo.Add(hotelsInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelsInfo", new { id = hotelsInfo.HotelId }, hotelsInfo);
        }

        // DELETE: api/HotelsInfo/5
        [HttpDelete("{id}")]
        //[Authorize(Policy = "AdminRole")]
        public async Task<IActionResult> DeleteHotelsInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotelsInfo = await _context.HotelsInfo.FindAsync(id);
            if (hotelsInfo == null)
            {
                return NotFound();
            }

            _context.HotelsInfo.Remove(hotelsInfo);
            await _context.SaveChangesAsync();

            return Ok(hotelsInfo);
        }

        private bool HotelsInfoExists(int id)
        {
            return _context.HotelsInfo.Any(e => e.HotelId == id);
        }
       
    }
}