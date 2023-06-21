using MovieReview.Database.Repositories.Interfaces.Base;
using MovieReview.Core.Domain.Base;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Interfaces.Base;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MovieReview.Database.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;
        private IBaseRepository<Review> repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public BaseService(IBaseRepository<Review> repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(T obj)
        {
            await _repository.AddAsync(obj);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(T obj)
        {
            await _repository.UpdateAsync(obj);
        }

        public async Task RemoveAsync(T obj)
        {
            await _repository.RemoveAsync(obj);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _repository.RemoveByIdAsync(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
