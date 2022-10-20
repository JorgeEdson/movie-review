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
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {

        protected readonly MovieReviewContext _context;
        public DbSet<T> _dbSet{ get; set; }

        public GenericRepository()
        {
            _context = new MovieReviewContext();
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T obj)
        {
            _dbSet.Add(obj);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T obj)
        {
            _dbSet.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T obj)
        {
            _dbSet.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var obj = _dbSet.Find(id);
            if (obj != null)
            {
                await RemoveAsync(obj);
            }
        }

        public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        
    }
}
