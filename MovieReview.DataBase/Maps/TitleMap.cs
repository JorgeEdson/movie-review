using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReview.Database.Maps.Base;
using MovieReview.Core.Domain.Entities;

namespace MovieReview.Core.Database.Maps
{
    public class TitleMap : EntityMap<Title>
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
            builder.Property(x => x.IdDirector).HasColumnName("IdDirector").IsRequired();
            builder.Property(x => x.IdScreenwriter).HasColumnName("IdScreenwriter").IsRequired();
            builder.Property(x => x.Duration).HasColumnName("Duration").IsRequired();
            builder.Property(x => x.Synopsis).HasColumnName("Synopsis").HasMaxLength(int.MaxValue).IsRequired();

            builder.HasOne(x => x.Director).WithMany(x => x.Titles).HasForeignKey(x => x.IdDirector);            
            builder.HasOne(x => x.Screenwriter).WithMany(x => x.Titles).HasForeignKey(x => x.IdScreenwriter);

            builder.HasMany(x => x.Actors).WithMany(x => x.Titles).UsingEntity<ActorTitle>(
                x => x.HasOne(f => f.Actor).WithMany().HasForeignKey(f => f.IdActor),
                x => x.HasOne(f => f.Title).WithMany().HasForeignKey(f => f.IdTitle),
                x => 
                { 
                    x.ToTable("ActorsTitles");

                    x.HasKey(f => new { f.IdActor,f.IdTitle }); 

                    x.Property(x => x.IdActor).HasColumnName("IdActor").IsRequired();
                    x.Property(x => x.IdTitle).HasColumnName("IdTitle").IsRequired();
                });
        }
    }
}
