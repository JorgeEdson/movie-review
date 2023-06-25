using MovieReview.Database.Repositories.Base;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Core.Domain.Entities;
using MovieReviewDataBase;

namespace MovieReview.Database.Repositories
{
    public class DirectorRepository : BaseRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(MovieReviewContext paramContext) : base(paramContext)
        {
        }
    }
}
