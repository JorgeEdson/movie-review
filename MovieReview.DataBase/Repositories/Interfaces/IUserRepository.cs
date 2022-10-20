using MovieReview.Database.Repositories.Interfaces.Base;
using MovieReview.Core.Domain.Entities;
using System.Threading.Tasks;

namespace MovieReview.Database.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByNameAndPasswordAsync(string name, string password);
    }
}
