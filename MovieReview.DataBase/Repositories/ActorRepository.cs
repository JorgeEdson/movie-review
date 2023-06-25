using MovieReview.Database.Repositories.Base;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Core.Domain.Entities;
using MovieReviewDataBase;

namespace MovieReview.Database.Repositories
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(MovieReviewContext paramContext) : base(paramContext)
        {
        }
    }
}
