using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Interfaces.Base;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MovieReview.Database.Services.Interfaces
{
    public interface IActorService : IBaseService<Actor>
    {
        Task CreateWithWhoAddedAsync(Actor paramObj, Guid paramWhoAddedId);
    }
}
