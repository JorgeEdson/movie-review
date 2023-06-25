using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Database.Services.Interfaces;
using System.Threading.Tasks;

namespace MovieReview.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _service;
        
        public TitleController(ITitleService titleService)
        {            
            _service = titleService;
        }

        [Authorize]
        [HttpGet("v1/Titles")]
        public async Task<IActionResult> Titles()
        {
            var titles = await _service.GetPagedAsync(0, 5);
            return Ok(titles);
        }
    }
}
