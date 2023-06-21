using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Repositories.Base;
using MovieReview.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Database.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public Task<List<User>> GetAllUsersAdm()
        {
            return _dbSet.Where(u => u.IsAdministrator).ToListAsync();
        }

        public Task<User> GetByEmailAndPasswordAsync(string paramEmail, string paramPassword)
        {
            return _dbSet.Where(u => u.Email.Equals(paramEmail) && u.Password.Equals(paramPassword)).FirstOrDefaultAsync();
        }

        public Task<User> GetByEmailAsync(string paramEmail)
        {
            return _dbSet.Where(u => u.Email.Equals(paramEmail)).FirstOrDefaultAsync();
        }
    }
}
