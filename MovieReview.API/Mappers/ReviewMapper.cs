using AutoMapper;
using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto.Reviews;

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
