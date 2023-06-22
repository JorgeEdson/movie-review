using AutoMapper;
using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto;

namespace MovieReview.API.Mappers
{
    public class ReviewMapper : Profile
    {
        public ReviewMapper()
        {
            CreateMap<ReviewRequestDto, Review>();
        }
    }
}
