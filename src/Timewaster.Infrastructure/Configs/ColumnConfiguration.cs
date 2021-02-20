using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Timewaster.Core.Entities.Projects;

namespace Timewaster.Infrastructure.Configs
{
    public class ColumnConfiguration : IEntityTypeConfiguration<Column>
    {
        public void Configure(EntityTypeBuilder<Column> builder)
        {
            builder.ToTable("Column");

            builder.Property(i => i.Id).UseHiLo("column").IsRequired();
            builder.Property(ci => ci.Title).IsRequired().HasMaxLength(50);
            builder.Property(ci => ci.PartitionKey).IsRequired();
        }
    }
}
