using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
              

        //public MovieReviewContext()
        //{
        //}

        //public MovieReviewContext(DbContextOptions<MovieReviewContext> options) : base(options)
        //{     
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Integrated Security=SSPI;" +
                                                          "Persist Security Info=False;" +
                                                          "Initial Catalog=MovieReviewDB;" +
                                                          "Data Source=ASUSDEV");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }        
    }
}
