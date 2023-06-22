using MovieReview.Database.Repositories.Interfaces.Base;
using MovieReview.Core.Domain.Base;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Services.Interfaces.Base;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace MovieReview.Database.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;        

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }        

        public async virtual Task CreateAsync(T paramObj)
        {
            await _repository.CreateAsync(paramObj);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(Guid paramId)
        {
            return await _repository.GetByIdAsync(paramId);
        }

        public async Task UpdateAsync(T paramObj)
        {
            await _repository.UpdateAsync(paramObj);
        }

        public async Task DeleteAsync(T paramObj)
        {
            await _repository.DeleteAsync(paramObj);
        }

        public async Task DeleteByIdAsync(Guid paramId)
        {
            await _repository.DeleteByIdAsync(paramId);
        }
    }
}
