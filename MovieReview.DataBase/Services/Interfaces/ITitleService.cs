using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Interfaces.Base;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using MovieReview.Core.Dto.Titles;

namespace MovieReview.Database.Services.Interfaces
{
    public interface ITitleService : IBaseService<Title>
    {
        Task CreateWithWhoAddedAsync(Title paramObj, Guid paramWhoAddedId);
        Task<List<TitleResponseDto>> GetPagedAsync(int paramPage, int paramPageSize);
        Task<bool> SaveTitleImage(string paramBase64Image);
    }
}
