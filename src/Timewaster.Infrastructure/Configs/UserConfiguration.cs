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
          
            builder.Property(i => i.JoinedAt).IsRequired();
            builder.Property(i => i.PartitionKey).IsRequired();
            builder.Property(i => i.ProfilePictureUrl).IsRequired(false);
            builder.Property(i => i.Username).IsRequired().HasMaxLength(32);
        }
    }
}
