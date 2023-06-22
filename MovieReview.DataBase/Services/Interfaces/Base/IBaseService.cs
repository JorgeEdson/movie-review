using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieReview.Core.Domain.Base;

namespace MovieReview.Database.Services.Interfaces.Base
{
    public interface IBaseService<T>  where T : BaseEntity
    {
        Task CreateAsync(T paramObj);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid paramId);
        Task UpdateAsync(T paramObj);
        Task DeleteAsync(T paramObj);
        Task DeleteByIdAsync(Guid paramId);
    }
}
