using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Entities.Board;
using Timewaster.Core.Entities.Socials;

namespace Timewaster.Infrastructure.Data
{
    public class TimewasterContext : DbContext
    {
        public TimewasterContext(DbContextOptions<TimewasterContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Discussion> Discussions { get; set; }

        protected override void  OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
