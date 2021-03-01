using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timewaster.Core.Entities.Projects;

namespace Timewaster.Infrastructure.Configs
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.Property(i => i.Id).UseHiLo("project").IsRequired();
            builder.Property(ci => ci.Name).IsRequired().HasMaxLength(50);
            builder.Property(ci => ci.Description).IsRequired(false).HasMaxLength(450);
            builder.Property(ci => ci.RefernceId).UseIdentityColumn().IsRequired();
            builder.Property(ci => ci.PartitionKey).IsRequired();
        }
    }
}
