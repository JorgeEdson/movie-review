using Microsoft.AspNetCore.Mvc;
using MovieReview.Core.Dto;
using MovieReview.WebApp.Services;
using MoviewReview.WebApp.Services.Interfaces;
using Refit;

namespace MovieReview.WebApp.Controllers
{
    public class LoginController : Controller
    {       
        IMovieReviewApiService _apiClient;

        public LoginController()
        {
            _apiClient = MovieReviewApiService.GetApiClient();
        }
        
        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(UserDto model)
        {
            var token = _apiClient.LoginAsync(model);
            return View(token);
        }
    }
}
