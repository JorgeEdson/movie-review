using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReview.Database.Maps.Base;
using MovieReview.Core.Domain.Entities;

namespace MovieReview.Core.Database.Maps
{
    public class TitleMap : BaseEntityMap<Title>
    {
        public TitleMap() : base("Titles")
        {
        }

        public override void Configure(EntityTypeBuilder<Title> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TypeMovie).HasColumnName("TypeMovie").IsRequired();
            builder.Property(x => x.Genre).HasColumnName("Genre").IsRequired();
            builder.Property(x => x.TitleMovie).HasColumnName("TitleMovie").HasMaxLength(50).IsRequired();
            builder.Property(x => x.DirectorId).HasColumnName("DirectorId").IsRequired();
            
            builder.Property(x => x.Duration).HasColumnName("Duration").IsRequired();
            builder.Property(x => x.Synopsis).HasColumnName("Synopsis").HasMaxLength(int.MaxValue).IsRequired();

            builder.HasOne(x => x.Director).WithMany(x => x.Titles).HasForeignKey(x => x.DirectorId);            
            

            builder.HasMany(x => x.Actors).WithMany(x => x.Titles).UsingEntity<ActorTitle>(
                x => x.HasOne(f => f.Actor).WithMany().HasForeignKey(f => f.ActorId),
                x => x.HasOne(f => f.Title).WithMany().HasForeignKey(f => f.TitleId),
                x => 
                { 
                    x.ToTable("ActorsTitles");

                    x.HasKey(f => new { f.Id }); 

                    x.Property(x => x.ActorId).HasColumnName("ActorId").IsRequired();
                    x.Property(x => x.TitleId).HasColumnName("TitleId").IsRequired();
                });
        }
    }
}
