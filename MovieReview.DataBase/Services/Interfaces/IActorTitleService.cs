using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto.Actors;
using MovieReview.Database.Services.Interfaces.Base;
using System;
using System.Threading.Tasks;

namespace MovieReview.Database.Services.Interfaces
{
    public interface IActorTitleService : IBaseService<ActorTitle>
    {
        Task CreateWithWhoAddedAsync(ActorsInTitleRequestDto objDto, Guid paramWhoAddedId);
    }
}
