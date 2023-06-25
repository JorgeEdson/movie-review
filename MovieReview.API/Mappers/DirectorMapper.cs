using AutoMapper;
using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto;
using MovieReview.Core.Dto.Persons;

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
