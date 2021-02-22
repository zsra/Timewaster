using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timewaster.Core.Entities.Accounts;

namespace Timewaster.Infrastructure.Configs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(i => i.Id).UseHiLo("user").IsRequired();
            builder.Property(i => i.Firstname).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Email).IsRequired().HasMaxLength(100);
            builder.Property(i => i.JoinedAt).IsRequired();
            builder.Property(i => i.Password).IsRequired();
            builder.Property(i => i.PartitionKey).IsRequired();
            builder.Property(i => i.ProfilePictureUrl).IsRequired(false);
            builder.Property(i => i.Username).IsRequired().HasMaxLength(32);
        }
    }
}
