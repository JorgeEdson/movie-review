using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MovieReview.Database.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MovieReview.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;
        
        public ReviewController(IReviewService reviewService)
        {            
            _service = reviewService;
        }

        [Authorize]
        [HttpGet("v1/Reviews")]
        public async Task<IActionResult> Reviews([FromServices]IMemoryCache paramCache)
        {
            var reviews = await paramCache.GetOrCreateAsync("ReviewsCache", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                return await _service.GetAllAsync();
            });

            return Ok(reviews);
        }
    }
}
