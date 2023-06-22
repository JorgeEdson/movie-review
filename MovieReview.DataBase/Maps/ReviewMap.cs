using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReview.Database.Maps.Base;
using MovieReview.Core.Domain.Entities;

namespace MovieReview.Core.Database.Maps
{
    public class ReviewMap : BaseEntityMap<Review>
    {
        public ReviewMap() : base("Reviews")
        {
        }

        public override void Configure(EntityTypeBuilder<Review> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Note).HasColumnName("Note").IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(int.MaxValue).IsRequired();
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(x => x.TitleId).HasColumnName("TitleId").IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Reviews).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Title).WithMany(x => x.Reviews).HasForeignKey(x => x.TitleId);
            
        }
    }
}
