using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using AutoMapper;
using MovieReview.Core.Dto.Users;
using MovieReview.Core.Dto.Titles;

namespace MovieReview.Database.Services
{
    public class TitleService : BaseService<Title>, ITitleService
    {
        private readonly ITitleRepository _repository;
        private readonly IMapper _mapper;

        public TitleService(ITitleRepository repository) : base(repository)
        {
            _repository = repository;
            var mapper = new MapperConfiguration(r => r.CreateMap<Title, TitleResponseDto>().ReverseMap());
            _mapper = mapper.CreateMapper();
        }

        public async Task CreateWithWhoAddedAsync(Title paramObj, Guid paramWhoAddedId)
        {
            paramObj.SetWhoAdded(paramWhoAddedId);
            await _repository.CreateAsync(paramObj);
        }

        public async Task<List<TitleResponseDto>> GetPagedAsync(int paramPage, int paramPageSize)
        {
            List<TitleResponseDto> result = new List<TitleResponseDto>();
            var titles = await _repository.GetPagedAsync(paramPage, paramPageSize);
            foreach (Title item in titles) 
            {
                var dto = _mapper.Map<TitleResponseDto>(item);
                result.Add(dto);
            }
            return result;
        }

        public async Task<bool> SaveTitleImage(string paramBase64Image)
        {
            var fileName = $"{Guid.NewGuid().ToString()}.jpg";
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(paramBase64Image, "");
            var bytes = Convert.FromBase64String(data);

            try
            {
                await System.IO.File.WriteAllBytesAsync($"wwwroot/images/{fileName}", bytes);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
