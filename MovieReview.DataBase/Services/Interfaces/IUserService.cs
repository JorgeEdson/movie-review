using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto.Request;
using MovieReview.Core.Dto.Response;
using MovieReview.Database.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReview.Database.Services.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> LoginAsync(LoginRequestDto paramLoginDto);
        Task<bool> ChangePasswordAsync(ChangePasswordRequestDto paramChangePasswordRequestDto);
        Task<User> GetByEmailAsync(string paramEmail);
        Task CreateOtherAdministratorAsync(User paramUser, Guid paramWhoAddedId);
        Task<List<UserResponseDto>> GetUsersAdmAsync();
    }
}
