using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Database.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string paramEmail);
        Task<User> GetByEmailAndPasswordAsync(string paramEmail, string paramPassword);
        Task<List<User>> GetAllUsersAdmAsync();
    }
}
