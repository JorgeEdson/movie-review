using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Repositories.Base;
using MovieReview.Database.Repositories.Interfaces;
using MovieReviewDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Database.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MovieReviewContext paramContext) : base(paramContext)
        {
        }

        public async Task<List<User>> GetAllUsersAdmAsync()
        {
            return await _dbSet.Where(u => u.IsAdministrator).ToListAsync();
        }

        public async Task<User> GetByEmailAndPasswordAsync(string paramEmail, string paramPassword)
        {
            return await _dbSet.Where(u => u.Email.Equals(paramEmail) && u.Password.Equals(paramPassword)).FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmailAsync(string paramEmail)
        {
            return await _dbSet.Where(u => u.Email.Equals(paramEmail)).FirstOrDefaultAsync();
        }
    }
}
