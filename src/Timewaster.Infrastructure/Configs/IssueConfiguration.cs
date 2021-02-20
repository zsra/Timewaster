using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Infrastructure.Configs
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("Issue");

            builder.Property(i => i.Id).UseHiLo("issue").IsRequired();
            builder.Property(ci => ci.Title).IsRequired().HasMaxLength(50);
            builder.Property(ci => ci.ReferenceNumber).UseIdentityColumn().IsRequired();
            builder.Property(ci => ci.Description).IsRequired(false).HasMaxLength(450);
            builder.Property(ci => ci.PartitionKey).IsRequired();
            builder.Property(ci => ci.CreatedAt).IsRequired();
        }
    }
}
