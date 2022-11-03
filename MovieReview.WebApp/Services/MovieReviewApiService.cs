using Microsoft.AspNetCore.Mvc;
using MovieReview.Core.Dto;
using MoviewReview.WebApp.Services.Interfaces;
using Refit;

namespace MovieReview.WebApp.Services
{
    public static class MovieReviewApiService
    {
        public static IMovieReviewApiService GetApiClient() 
        {
            return RestService.For<IMovieReviewApiService>("https://localhost:7029/api");
        }
    }
}
