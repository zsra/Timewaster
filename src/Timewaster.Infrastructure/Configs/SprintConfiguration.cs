using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Entities.Projects;

namespace Timewaster.Infrastructure.Configs
{
    public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
    {
        public void Configure(EntityTypeBuilder<Sprint> builder)
        {
            builder.ToTable("Sprints");

            builder.Property(i => i.Id).UseHiLo("sprint").IsRequired();
            builder.Property(ci => ci.CreatedAt).IsRequired();
            builder.Property(ci => ci.ClosingAt).IsRequired();
            builder.Property(ci => ci.PartitionKey).IsRequired();
            builder.Property(ci => ci.ReferenceKey).UseIdentityColumn().IsRequired();
        }
    }
}
