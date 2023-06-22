using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace MovieReview.Database.Services
{
    public class TitleService : BaseService<Title>, ITitleService
    {
        private readonly ITitleRepository _repository;

        public TitleService(ITitleRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task CreateWithWhoAddedAsync(Title paramObj, Guid paramWhoAddedId)
        {
            paramObj.SetWhoAdded(paramWhoAddedId);
            await _repository.CreateAsync(paramObj);
        }
    }
}
