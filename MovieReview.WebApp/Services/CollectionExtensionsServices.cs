using MoviewReview.WebApp.Services.Interfaces;
using Refit;

namespace MovieReview.WebApp.Services
{
    public static class CollectionExtensionsServices
    {
        private const string ConfigExternalMoviereviewApi = "External:MovieReviewApi";

        public static IServiceCollection AddExternalApiClients(this IServiceCollection service, IConfiguration configuration) 
        { 
            var baseUrlMovieReviewApi = configuration[ConfigExternalMoviereviewApi];
            service.AddRefitClient<IMovieReviewApiService>()
                   .ConfigureHttpClient(config => config.BaseAddress = new Uri(baseUrlMovieReviewApi));

            return service;
        }
    }
}
