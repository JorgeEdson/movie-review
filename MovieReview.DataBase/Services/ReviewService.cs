using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;

namespace MovieReview.Database.Services
{
    public class ReviewService : GenericService<Review>, IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
