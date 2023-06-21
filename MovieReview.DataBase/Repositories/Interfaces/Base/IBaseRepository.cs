using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MovieReview.Core.Domain.Base;


namespace MovieReview.Database.Repositories.Interfaces.Base
{
    public interface IBaseRepository<T>  where T : BaseEntity
    {
        Task CreateAsync(T paramObj);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid paramId);        
        Task UpdateAsync(T paramObj);
        Task DeleteAsync(T paramObj);
        Task DeleteByIdAsync(Guid paramId);        
    }
}
