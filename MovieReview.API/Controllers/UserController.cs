using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Interfaces;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using AutoMapper;
using MovieReview.API.Services;
using MovieReview.Core.Dto.Request;
using MovieReview.Core.Dto;
using MovieReview.API.Attributes;

namespace MovieReview.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;
        private readonly TokenService _tokenService;
        public UserController(IMapper mapper, IUserService reviewService, TokenService tokenService)
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
                var user = await _service.LoginAsync(paramLoginDto);
                if (user != null)
                {
                    var token = _tokenService.GenerateToken(user);
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
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto paramRegisterRequestDto, [FromServices] EmailService paramEmailService)
        {
            var user = _mapper.Map<User>(paramRegisterRequestDto);
            await _service.CreateAsync(user);

            paramEmailService.Send(
                user.Name,
                user.Email,
                "Welcome to Movie Review",
                "Welcome! Your Password is <strong>123</strong>");

                return Created(nameof(user), user);
        }

        [Authorize]
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDto paramChangePasswordDto)
        {
            try
            {
                var flag = await _service.ChangePasswordAsync(paramChangePasswordDto);
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
        [HttpPost("CreateOtherAdministrator")]
        public async Task<IActionResult> CreateOtherAdministrator([FromBody] RegisterRequestDto paramRegisterRequestDto)
        {
            try
            {
                var whoAddedId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var user = _mapper.Map<User>(paramRegisterRequestDto);
                await _service.CreateOtherAdministratorAsync(user, whoAddedId);
                return Created(nameof(user), user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateActor")]
        public async Task<IActionResult> CreateActor([FromBody] PersonRequestDto paramPersonDto,
            [FromServices] IActorService paramActorService)
        {
            try
            {
                var whoAddedId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var actor = _mapper.Map<Actor>(paramPersonDto);
                await paramActorService.CreateWithWhoAddedAsync(actor, whoAddedId);
                return Created(nameof(actor), actor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateDirector")]
        public async Task<IActionResult> CreateDirector([FromBody] PersonRequestDto paramPersonDto,
            [FromServices] IDirectorService paramDirectorService)
        {
            try
            {
                var whoAddedId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var director = _mapper.Map<Director>(paramPersonDto);
                await paramDirectorService.CreateWithWhoAddedAsync(director, whoAddedId);
                return Created(nameof(director), director);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateTitle")]
        public async Task<IActionResult> CreateTitle([FromBody] TitleRequestDto paramTitleDto,
            [FromServices] ITitleService paramTitleService)
        {
            var whoAddedId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var title = _mapper.Map<Title>(paramTitleDto);
            await paramTitleService.CreateWithWhoAddedAsync(title, whoAddedId);
            return Created(nameof(title), title);
        }

        [Authorize]
        [HttpPost("CreateActorsInTitle")]
        public async Task<IActionResult> CreateActorsInTitle([FromBody] ActorsInTitleRequestDto paramActorsInTitleRequestDto,
            [FromServices] IActorTitleService paramActorTitleService)
        {
            try
            {
                var whoAddedId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                await paramActorTitleService.CreateWithWhoAddedAsync(paramActorsInTitleRequestDto, whoAddedId);
                return Created(nameof(paramActorsInTitleRequestDto), paramActorsInTitleRequestDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview([FromBody] ReviewRequestDto paramReviewRequestDto,
            [FromServices] IReviewService paramReviewService)
        {
            
                var whoAddedId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var review = _mapper.Map<Review>(paramReviewRequestDto);
                await paramReviewService.CreateWithWhoAddedAsync(review, whoAddedId);
                return Created(nameof(review), review);
            
        }

        [ApiKey]
        [HttpGet("GetUsersAdm")]
        public async Task<IActionResult> GetUsersAdm()
        {
            try
            {
                var list = await _service.GetUsersAdmAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}