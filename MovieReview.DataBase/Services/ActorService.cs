using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;


namespace MovieReview.Database.Services
{
    public class ActorService : GenericService<Actor>, IActorService
    {
        private readonly IActorRepository _repository;
        public ActorService(IActorRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
