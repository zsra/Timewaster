using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Infrastructure.Configs
{
    public class StoryConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.ToTable("Stories");

            builder.Property(i => i.Id).UseHiLo("story").IsRequired();
            builder.Property(ci => ci.Name).IsRequired().HasMaxLength(50);
            builder.Property(ci => ci.Description).IsRequired(false).HasMaxLength(450);
            builder.Property(ci => ci.PartitionKey).IsRequired();
        }
    }
}
