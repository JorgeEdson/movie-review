using Microsoft.AspNetCore.Mvc;
using MoviewReview.WebApp.Services.Interfaces;
using MovieReview.Core.Dto;

namespace MovieReview.WebApp.Controllers
{
    public class LoginController : Controller
    {   
        private readonly IMovieReviewApiService _movieReviewApiService;

        public LoginController(IMovieReviewApiService movieReviewApiService)
        {
            _movieReviewApiService = movieReviewApiService;
        }
        
        
        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(UserDto model)
        {
            try
            {
                var token = await _movieReviewApiService.LoginAsync(model);
                
                return View();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}