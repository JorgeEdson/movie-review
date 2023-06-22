﻿using AutoMapper;
using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Dto;

namespace MovieReview.API.Mappers
{
    public class TitleMapper:Profile
    {
        public TitleMapper()
        {
            CreateMap<TitleRequestDto, Title>();
        }
    }
}
