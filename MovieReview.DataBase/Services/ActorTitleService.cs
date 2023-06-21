using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;

namespace MovieReview.Database.Services
{
    public class ActorTitleService : BaseService<ActorTitle>, IActorTitleService
    {
        private readonly IActorTitleRepository _repository;
        public ActorTitleService(IActorTitleRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
