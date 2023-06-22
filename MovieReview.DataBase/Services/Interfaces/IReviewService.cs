using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Interfaces.Base;
using System.Threading.Tasks;
using System;

namespace MovieReview.Database.Services.Interfaces
{
    public interface IReviewService : IBaseService<Review>
    {
        Task CreateWithWhoAddedAsync(Review paramObj, Guid paramWhoAddedId);
    }
}
