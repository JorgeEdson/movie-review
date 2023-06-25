using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReview.Database.Maps.Base;
using MovieReview.Core.Domain.Entities;

namespace MovieReview.Core.Database.Maps
{
    public  class DirectorMap : BaseEntityMap<Director>
    {
        public DirectorMap() : base("Directors")
        {

        }

        public override void Configure(EntityTypeBuilder<Director> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(x => x.BirthDate).HasColumnName("BirthDate").IsRequired();
        }
    }
}
