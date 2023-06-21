using MovieReview.Database.Repositories.Base;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Core.Domain.Entities;

namespace MovieReview.Database.Repositories
{
    public class TitleRepository : BaseRepository<Title>, ITitleRepository
    {
    }
}
