using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieReview.Core.Domain.Entities;

namespace MovieReviewDataBase
{
    public class MovieReviewContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }


        public MovieReviewContext(DbContextOptions<MovieReviewContext> paramOptions) : base(paramOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }        
    }
}
