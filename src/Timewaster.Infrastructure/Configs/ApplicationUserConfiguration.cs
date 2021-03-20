using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timewaster.Core.Entities.Accounts;

namespace Timewaster.Infrastructure.Configs
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers");

            builder.Property(i => i.Id).UseHiLo("applicationuser").IsRequired();
            builder.Property(i => i.Firstname).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Email).IsRequired().HasMaxLength(100);
            builder.Property(i => i.UserName).IsRequired().HasMaxLength(40);
        }
    }
}
