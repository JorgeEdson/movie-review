using AutoMapper;
using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto.Request;
using MovieReview.Core.Dto.Response;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReview.Database.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly EncryptationService _encryptationService;
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
            var mapper = new MapperConfiguration(r => r.CreateMap<User, UserResponseDto>().ReverseMap());
            _mapper = mapper.CreateMapper();
            _encryptationService = new EncryptationService();
        }

        public async Task<User> LoginAsync(LoginRequestDto paramLoginDto) =>
             await GetByEmailAndPasswordAsync(paramLoginDto.Email, paramLoginDto.Password);        

        public async Task<bool> ChangePasswordAsync(ChangePasswordRequestDto paramChangePasswordRequestDto)
        {
            bool canAcessRepository = paramChangePasswordRequestDto.OldPassword !=
                                                      paramChangePasswordRequestDto.NewPassword;
            if (canAcessRepository)
            {
                var encryptedPassword = _encryptationService.AddCryptography(paramChangePasswordRequestDto.NewPassword);
                var user = await GetByEmailAndPasswordAsync(paramChangePasswordRequestDto.Email, paramChangePasswordRequestDto.OldPassword);
                user.SetPassword(encryptedPassword);
                await _repository.UpdateAsync(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> GetByEmailAsync(string paramEmail)
        {
            bool canAcessRepository = paramEmail != null && paramEmail != string.Empty;
            if (canAcessRepository)
            {
                return await _repository.GetByEmailAsync(paramEmail);
            }
            else
            {
                return null;
            }
        }

        public async Task CreateOtherAdministratorAsync(User paramUser, Guid paramWhoAddedId)
        {
            paramUser.SetToAdministrator();
            paramUser.SetWhoAdded(paramWhoAddedId);
            await CreateAsync(paramUser);
        }

        public async Task<List<UserResponseDto>>  GetUsersAdmAsync()
        {
            List<UserResponseDto> result = new List<UserResponseDto>();
            var users = await _repository.GetAllUsersAdmAsync();
            foreach (User item in users)
            {
                var dto = _mapper.Map<UserResponseDto>(item);
                if (item.UserId != null)
                {
                    var user = await _repository.GetByIdAsync((Guid)item.UserId);
                    dto.AddedBy = user.Name;
                }
                result.Add(dto);
            }
            return result;
        }

        private async Task<User> GetByEmailAndPasswordAsync(string paramEmail, string paramPassword)
        {
            _ = paramEmail != null;
            bool canAcessRepository = paramPassword != null;
            if (canAcessRepository) 
            {
                var encryptedPassword = _encryptationService.AddCryptography(paramPassword);
                return await _repository.GetByEmailAndPasswordAsync(paramEmail, encryptedPassword);
            }
            
            else
                return null;
        }
    }
}
