using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Interfaces.Base;
using System.Threading.Tasks;
using System;

namespace MovieReview.Database.Services.Interfaces
{
    public interface IDirectorService : IBaseService<Director>
    {
        Task CreateWithWhoAddedAsync(Director paramObj, Guid paramWhoAddedId);
    }
}
