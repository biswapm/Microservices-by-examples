using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reviews.API.Extensions
{
    interface IRedisReviewRepository
    {
        Task<IEnumerable<Models.Reviews>> GetReviewsAsync(string hotelId);
        Task<Models.Reviews> UpdateReviewsAsync(Models.Reviews reviews);
        Task<bool> DeleteReviewsAsync(string id);
        IEnumerable<string> GetUsers();
    }
}
