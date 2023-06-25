using MovieReview.Database.Repositories.Base;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Core.Domain.Entities;
using MovieReviewDataBase;

namespace MovieReview.Database.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieReviewContext paramContext) : base(paramContext)
        {
        }
    }
}
