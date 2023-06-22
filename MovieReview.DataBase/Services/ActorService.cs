using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace MovieReview.Database.Services
{
    public class ActorService : BaseService<Actor>, IActorService
    {
        private readonly IActorRepository _repository;
        public ActorService(IActorRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task CreateWithWhoAddedAsync(Actor paramObj, Guid paramWhoAddedId) 
        {
            paramObj.SetWhoAdded(paramWhoAddedId);
            await _repository.CreateAsync(paramObj);
        }
    }
}
