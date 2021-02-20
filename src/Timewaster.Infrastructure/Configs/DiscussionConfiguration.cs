using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timewaster.Core.Entities.Socials;

namespace Timewaster.Infrastructure.Configs
{
    public class DiscussionConfiguration : IEntityTypeConfiguration<Discussion>
    {
        public void Configure(EntityTypeBuilder<Discussion> builder)
        {
            builder.ToTable("Discussion");

            builder.Property(i => i.Id).UseHiLo("discussion").IsRequired();
            builder.Property(ci => ci.OpenedAt).IsRequired();
            builder.Property(ci => ci.PartitionKey).IsRequired();
            builder.Property(ci => ci.ClosedAt).IsRequired();
        }
    }
}
