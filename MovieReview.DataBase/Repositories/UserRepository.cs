using Microsoft.EntityFrameworkCore;
using MovieReview.Database.Repositories.Base;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Core.Domain.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace MovieReview.Database.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository() : base()
        {
        }

        public async Task<User> GetByNameAndPasswordAsync(string name, string password)
        {
            return await _dbSet.Where(x => x.Name.Equals(name) && x.Password.Equals(password)).FirstOrDefaultAsync();
        }
    }
}
