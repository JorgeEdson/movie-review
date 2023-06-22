using AutoMapper;
using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto;

namespace MovieReview.API.Mappers
{
    public class ActorMapper : Profile
    {
        public ActorMapper()
        {
            CreateMap<PersonRequestDto, Actor>();
        }
    }
}
