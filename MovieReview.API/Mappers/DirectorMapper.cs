using AutoMapper;
using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto;

namespace MovieReview.API.Mappers
{
    public class DirectorMapper:Profile
    {
        public DirectorMapper()
        {
            CreateMap<PersonRequestDto, Director>();
        }
    }
}
