using AutoMapper;
using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto;
using MovieReview.Core.Dto.Users;

namespace MovieReview.API.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {                   
            CreateMap<RegisterRequestDto, User>();            
        }
    }
}
