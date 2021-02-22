using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Infrastructure.Configs
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Statuses");

            builder.Property(i => i.Id).UseHiLo("status").IsRequired();
            builder.Property(ci => ci.Name).IsRequired().HasMaxLength(20);
            builder.Property(ci => ci.PartitionKey).IsRequired();
        }
    }
}
