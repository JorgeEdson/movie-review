using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;

namespace MovieReview.Database.Services
{
    public class ScreenwriterService : GenericService<Screenwriter>, IScreenwriterService
    {
        private readonly IScreenwriterRepository _repository;

        public ScreenwriterService(IScreenwriterRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
