using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timewaster.Core.Entities.Accounts;

namespace Timewaster.Infrastructure.Configs
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.Property(i => i.Id).UseHiLo("team").IsRequired();
            builder.Property(ci => ci.Name).IsRequired().HasMaxLength(50);
            builder.Property(ci => ci.OwnerId).IsRequired();
            builder.Property(ci => ci.CreatedAt).IsRequired();
            builder.Property(ci => ci.ReferenceKey).UseIdentityColumn().IsRequired();
            builder.Property(ci => ci.PartitionKey).IsRequired();
        }
    }
}
