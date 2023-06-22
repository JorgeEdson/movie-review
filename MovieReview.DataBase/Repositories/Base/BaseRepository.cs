using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieReviewDataBase;
using MovieReview.Database.Repositories.Interfaces.Base;
using MovieReview.Core.Domain.Base;



namespace MovieReview.Database.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected readonly MovieReviewContext _context;
        public DbSet<T> _dbSet{ get; set; }

        public BaseRepository()
        {
            _context = new MovieReviewContext();
            _dbSet = _context.Set<T>();
        }

        public async virtual Task CreateAsync(T paramObj)
        {
            _dbSet.Add(paramObj);
            await _context.SaveChangesAsync();            
        }

        public async virtual Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async virtual Task<T> GetByIdAsync(Guid paramId)
        {
            return await _dbSet.FindAsync(paramId);
        }

        public async virtual Task UpdateAsync(T paramObj)
        {
            _dbSet.Update(paramObj);
            await _context.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(T paramObj)
        {
            _dbSet.Remove(paramObj);
            await _context.SaveChangesAsync();
        }

        public async virtual Task DeleteByIdAsync(Guid paramId)
        {
            var obj = _dbSet.Find(paramId);
            if (obj != null)
            {
                await DeleteAsync(obj);
            }
        }
    }
}
