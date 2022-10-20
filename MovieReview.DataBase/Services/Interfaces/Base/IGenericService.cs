using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieReview.Core.Domain.Base;

namespace MovieReview.Database.Services.Interfaces.Base
{
    public interface IGenericService<T> : IDisposable where T : Entity
    {
        Task AddAsync(T obj);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T obj);
        Task RemoveAsync(T obj);
        Task DeleteByIdAsync(int id);
    }
}
