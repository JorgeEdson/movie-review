using AutoMapper;
using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto;

namespace MovieReview.API.Mappers
{
    public class ActorTitleMapper : Profile
    {
        public ActorTitleMapper()
        {
            CreateMap<ActorsInTitleRequestDto, ActorTitle>();
        }
    }
}
