using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Core.Dto;
using MovieReview.API.Services.Interfaces;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MovieReview.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<string> Login([FromBody] UserDto model)
        {
            try
            {
                var userResult = await _userService.GetByNameAndPasswordAsync(model.Name, model.Password);
                if (userResult == null)
                    return "User Not Found";
                return _tokenService.GenerateToken(userResult);
            }
            catch (Exception ex)
            {
                return "Bad request";
            }
        }

        // GET: api/<UserController>
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _userService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST api/<UserController>
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] User user)
        {
            try
            {
                await _userService.AddAsync(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("Update")]
        public IActionResult Update(User user)
        {
            try
            {
                _userService.UpdateAsync(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                _userService.DeleteByIdAsync(id);
                return Ok("User Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}