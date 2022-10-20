using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;
using System.Threading.Tasks;

namespace MovieReview.Database.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<User> GetByNameAndPasswordAsync(string name, string password)
        {
            return _repository.GetByNameAndPasswordAsync(name, password);
        }
    }
}
