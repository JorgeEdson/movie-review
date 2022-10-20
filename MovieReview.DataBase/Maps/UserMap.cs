using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReview.Database.Maps.Base;
using MovieReview.Core.Domain.Entities;

namespace MovieReview.Core.Database.Maps
{
    public class UserMap : EntityMap<User>
    {
        public UserMap() : base("Users")
        {
        }

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Role).HasColumnName("Role").IsRequired();
        }
    }
}
