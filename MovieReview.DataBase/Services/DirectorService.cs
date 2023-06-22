using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace MovieReview.Database.Services
{
    public class DirectorService : BaseService<Director>, IDirectorService
    {
        private readonly IDirectorRepository _repository;
        public DirectorService(IDirectorRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task CreateWithWhoAddedAsync(Director paramObj, Guid paramWhoAddedId)
        {
            paramObj.SetWhoAdded(paramWhoAddedId);
            await _repository.CreateAsync(paramObj);
        }
    }
}
