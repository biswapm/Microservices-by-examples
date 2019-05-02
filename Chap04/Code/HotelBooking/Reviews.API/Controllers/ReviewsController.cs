using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Reviews.API.Models;
using Reviews.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Reviews.API.Services;

namespace Reviews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewsController : ControllerBase
    {
        private readonly HotelreviewsContext _context;
        private readonly IDistributedCache _distributedCache;
        private readonly IIdentityService _identitySvc;
        private string Cachekey = "ReviewRedisCache"; 
        public ReviewsController(HotelreviewsContext context, IDistributedCache distributedCache)
        {
            _context = context;
            _distributedCache = distributedCache;

        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<IEnumerable<Models.Reviews>> GetReviews([FromRoute] string hotelid)
        {

            IEnumerable<Models.Reviews> reviews = null;
            if (!string.IsNullOrEmpty(Cachekey))
            {
                reviews = await _distributedCache.GetAsync<IEnumerable<Models.Reviews>>(Cachekey);

            }
            else
            {
                reviews = _context.Reviews.Where(p => p.HotelId.Equals(hotelid));
                await _distributedCache.SetAsync<IEnumerable<Models.Reviews>>(Cachekey, reviews, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2) });
            }
            return reviews;
        }

        
        // POST: api/Reviews
        [HttpPost]
        public async Task<IActionResult> PostReviews([FromBody] Models.Reviews reviews)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Reviews.Add(reviews);
           
            try
            {
                await _context.SaveChangesAsync();
                //make cache null
                _distributedCache.Remove(Cachekey);
                
            }
            catch (DbUpdateException)
            {
                if (ReviewsExists(reviews.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReviews", new { id = reviews.Id }, reviews);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviews([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();

            return Ok(reviews);
        }

        private bool ReviewsExists(string id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}