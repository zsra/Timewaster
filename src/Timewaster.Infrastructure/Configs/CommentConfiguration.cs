using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timewaster.Core.Entities.Socials;

namespace Timewaster.Infrastructure.Configs
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.Property(i => i.Id).UseHiLo("comment").IsRequired();
            builder.Property(ci => ci.Text).IsRequired().HasMaxLength(450);
            builder.Property(ci => ci.CreatedAt).IsRequired();
            builder.Property(ci => ci.PartitionKey).IsRequired();
        }
    }
}
