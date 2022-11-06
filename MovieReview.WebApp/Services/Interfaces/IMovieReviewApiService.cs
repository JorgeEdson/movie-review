using Microsoft.AspNetCore.Mvc;
using MovieReview.Core.Dto;
using Refit;

namespace MoviewReview.WebApp.Services.Interfaces
{
    public interface IMovieReviewApiService
    {

        //[Headers("Authorization: Bearer")]


        [Post("/User/Login")]        
        Task<string> LoginAsync([Body] UserDto model);
    }
}
