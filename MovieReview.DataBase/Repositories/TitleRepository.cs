using MovieReview.Database.Repositories.Base;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Core.Domain.Entities;
using MovieReviewDataBase;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieReview.Database.Repositories
{
    public class TitleRepository : BaseRepository<Title>, ITitleRepository
    {
        public TitleRepository(MovieReviewContext paramContext) : base(paramContext)
        {
        }

        public async Task<List<Title>> GetPagedAsync(int paramPage, int paramPageSize)
        {
            return await _dbSet.Include(t => t.Director)
                .Skip(paramPage * paramPageSize)
                .Take(paramPageSize)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();            
        }
    }
}
