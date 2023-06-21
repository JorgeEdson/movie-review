using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Interfaces;
using System.Security.Claims;
using System;
using System.Threading.Tasks;

namespace MovieReview.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ReviwerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReviwerService _service;
        private readonly TokenService _tokenService;
        public ReviwerController(IMapper mapper, IReviwerService reviewService, TokenService tokenService)
        {
            _mapper = mapper;
            _service = reviewService;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto paramLoginDto)
        {
            try
            {
                var reviwer = _service.Login(paramLoginDto);
                if (reviwer != null)
                {
                    var token = _tokenService.GenerateToken(reviwer);
                    return Ok(token);
                }
                else
                    return Unauthorized("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] PersonRequestDto paramPersonDto)
        {
            try
            {
                var reviwer = _mapper.Map<Reviwer>(paramPersonDto);
                await _service.AddAsync(reviwer);
                return Created(nameof(reviwer), reviwer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDto paramChangePasswordDto)
        {
            try
            {
                var flag = _service.ChangePassword(paramChangePasswordDto);
                if (flag)
                    return NoContent();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddOtherAdministrator")]
        public async Task<IActionResult> AddOtherAdministrator([FromBody] PersonRequestDto paramPersonRequestDto)
        {
            try
            {
                var whoAddedId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var reviwer = _mapper.Map<Reviwer>(paramPersonRequestDto);
                await _service.AddOtherAdministrator(reviwer, whoAddedId);
                return Created(nameof(reviwer), reviwer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddActor")]
        public async Task<IActionResult> AddActor([FromBody] PersonRequestDto paramPersonDto,
            [FromServices] IActorService paramActorService)
        {
            try
            {
                var whoAddedId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var actor = _mapper.Map<Actor>(paramPersonDto);
                await paramActorService.AddAsync(actor, whoAddedId);
                return Created(nameof(actor), actor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddDirector")]
        public async Task<IActionResult> AddDirector([FromBody] PersonRequestDto paramPersonDto,
            [FromServices] IDirectorService paramDirectorService)
        {
            try
            {
                var whoAddedId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var director = _mapper.Map<Director>(paramPersonDto);
                await paramDirectorService.AddAsync(director, whoAddedId);
                return Created(nameof(director), director);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddTitle")]
        public async Task<IActionResult> AddTitle([FromBody] TitleRequestDto paramTitleDto,
            [FromServices] ITitleService paramTitleService)
        {
            var whoAddedId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var title = _mapper.Map<Title>(paramTitleDto);
            await paramTitleService.AddAsync(title, whoAddedId);
            return Created(nameof(title), title);
        }

        [Authorize]
        [HttpPost("AddActorsInTitle")]
        public async Task<IActionResult> AddActorsInTitle([FromBody] ActorsInTitleRequestDto paramActorsInTitleRequestDto,
            [FromServices] IActorTitleService paramActorTitleService)
        {
            try
            {
                var whoAddedId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                await paramActorTitleService.AddActorsInTitleAsync(paramActorsInTitleRequestDto, whoAddedId);
                return Created(nameof(paramActorsInTitleRequestDto), paramActorsInTitleRequestDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReview([FromBody] ReviewRequestDto paramReviewRequestDto,
            [FromServices] IReviewService paramReviewService)
        {
            try
            {
                var whoAddedId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var review = _mapper.Map<Review>(paramReviewRequestDto);
                await paramReviewService.AddAsync(review, whoAddedId);
                return Created(nameof(review), review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetReviersAdm")]
        public async Task<IActionResult> GetReviersAdm()
        {
            try
            {
                var list = _service.GetReviersAdm();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}