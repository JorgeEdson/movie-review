using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReview.Core.Domain.Entities;
using MovieReview.Database.Maps.Base;


namespace MovieReview.Database.Maps
{
    public class UserMap : BaseEntityMap<User>
    {
        public UserMap() :base("Users")
        {}

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(x => x.BirthDate).HasColumnName("BirthDate").IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").IsRequired();
            builder.Property(x => x.IsAdministrator).HasColumnName("IsAdministrator").IsRequired();
        }
    }
}
