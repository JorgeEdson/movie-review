using MovieReview.Database.Repositories.Base;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Core.Domain.Entities;
using MovieReviewDataBase;

namespace MovieReview.Database.Repositories
{
    public class ActorTitleRepository : BaseRepository<ActorTitle>, IActorTitleRepository
    {
        public ActorTitleRepository(MovieReviewContext paramContext) : base(paramContext)
        {
        }
    }
}
