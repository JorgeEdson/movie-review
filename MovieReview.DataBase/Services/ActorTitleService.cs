using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;
using MovieReview.Core.Dto;
using System.Threading.Tasks;
using System;

namespace MovieReview.Database.Services
{
    public class ActorTitleService : BaseService<ActorTitle>, IActorTitleService
    {
        private readonly IActorTitleRepository _repository;
        public ActorTitleService(IActorTitleRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task CreateWithWhoAddedAsync(ActorsInTitleRequestDto objDto, Guid paramWhoAddedId)
        {
            foreach (Guid IdActor in objDto.IdsActors)
            {
                var actorTitle = new ActorTitle(objDto.IdTitle, IdActor);
                actorTitle.SetWhoAdded(paramWhoAddedId);
                await _repository.CreateAsync(actorTitle);
            }
        }

    }
}
