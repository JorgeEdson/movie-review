using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Database.Services.Base;
using MovieReview.Database.Services.Interfaces;

namespace MovieReview.Database.Services
{
    public class DirectorService : BaseService<Director>, IDirectorService
    {
        private readonly IDirectorRepository _repository;
        public DirectorService(IDirectorRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
