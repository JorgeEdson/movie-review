using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;

namespace MovieReview.Database.Services
{
    public class TitleService : BaseService<Title>, ITitleService
    {
        private readonly ITitleRepository _repository;

        public TitleService(ITitleRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
