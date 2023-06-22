using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MovieReview.Database.Services
{
    public class ReviewService : BaseService<Review>, IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task CreateWithWhoAddedAsync(Review paramObj, Guid paramWhoAddedId)
        {
            paramObj.SetWhoAdded(paramWhoAddedId);
            if (paramObj.Note >= 0 && paramObj.Note <= 10)
                await _repository.CreateAsync(paramObj);
            else
                throw new Exception("This note is note allowed");
        }
    }
}
