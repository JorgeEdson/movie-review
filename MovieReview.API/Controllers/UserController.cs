using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Interfaces;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using AutoMapper;
using MovieReview.API.Services;
using MovieReview.API.Attributes;
using MovieReview.Core.Dto.Titles;
using MovieReview.Core.Dto.Users;
using MovieReview.Core.Dto.Actors;
using MovieReview.Core.Dto.Reviews;
using MovieReview.Core.Dto.Persons;

namespace MovieReview.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;
        private readonly TokenService _tokenService;
        public UserController(IMapper mapper, IUserService userService, TokenService tokenService)
        {
            _mapper = mapper;
            _service = userService;
            _tokenService = tokenService;
        }

        [HttpPost("v1/Login")]
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

        [HttpPost("v1/Register")]
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
        [HttpPut("v1/ChangePassword")]
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
        [HttpPost("v1/CreateOtherAdministrator")]
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
        [HttpPost("v1/CreateActor")]
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
        [HttpPost("v1/CreateDirector")]
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
        [HttpPost("v1/CreateTitle")]
        public async Task<IActionResult> CreateTitle([FromBody] TitleRequestDto paramTitleDto,
            [FromServices] ITitleService paramTitleService)
        {
            var whoAddedId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var title = _mapper.Map<Title>(paramTitleDto);
            await paramTitleService.CreateWithWhoAddedAsync(title, whoAddedId);
            await paramTitleService.SaveTitleImage(paramTitleDto.Base64Image);
            return Created(nameof(title), title);
        }

        [Authorize]
        [HttpPost("v1/CreateActorsInTitle")]
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
        [HttpPost("v1/CreateReview")]
        public async Task<IActionResult> CreateReview([FromBody] ReviewRequestDto paramReviewRequestDto,
            [FromServices] IReviewService paramReviewService)
        {
            
                var whoAddedId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var review = _mapper.Map<Review>(paramReviewRequestDto);
                await paramReviewService.CreateWithWhoAddedAsync(review, whoAddedId);
                return Created(nameof(review), review);
            
        }

        [ApiKey]
        [HttpGet("v1/GetUsersAdm")]
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