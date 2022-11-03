using Microsoft.AspNetCore.Mvc;
using MovieReview.Core.Dto;
using Refit;

namespace MoviewReview.WebApp.Services.Interfaces
{
    public interface IMovieReviewApiService
    {
        [Post("/User/Login")]
        Task<Dictionary<string, string>> LoginAsync([FromBody] UserDto model);
    }
}
