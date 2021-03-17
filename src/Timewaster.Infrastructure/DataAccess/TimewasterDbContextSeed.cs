using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Entities.Projects;
using System.Linq;

namespace Timewaster.Infrastructure.DataAccess
{
    public class TimewasterDbContextSeed
    {
        private static readonly string GLOBAL_PARTITION_KEY = "PK_GLOBAL";
        private static readonly string LORUM_IPSUM = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla tempus hendrerit neque at porttitor. Vestibulum elementum velit odio, at volutpat enim euismod eu.";

        public static async Task SeedAsync(TimewasterDbContext context,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if(!await context.Statuses.AnyAsync())
                {
                    await context.Statuses.AddRangeAsync(GetDefaultStatuses());
                    await context.SaveChangesAsync();
                }
#if DEBUG
                if (!await context.Projects.AnyAsync())
                {
                    await context.Projects.AddRangeAsync(GetProjects());
                    await context.SaveChangesAsync();
                }

                if (!await context.Sprints.AnyAsync())
                {
                    await context.Sprints.AddRangeAsync(GetSprints());
                    await context.SaveChangesAsync();
                }
#endif
            }
            catch( Exception e)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<TimewasterDbContext>();
                    log.LogError(e.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Status> GetDefaultStatuses() => new List<Status> {
            new Status { Name = "To do", PartitionKey = GLOBAL_PARTITION_KEY },
            new Status { Name = "In progress", PartitionKey = GLOBAL_PARTITION_KEY },
            new Status { Name = "Testing", PartitionKey = GLOBAL_PARTITION_KEY },
            new Status { Name = "Done", PartitionKey = GLOBAL_PARTITION_KEY },
        };

        private static IEnumerable<Project> GetProjects() => new List<Project> {
            new Project { Name = "Project #1", Description = LORUM_IPSUM, PartitionKey = GLOBAL_PARTITION_KEY },
            new Project { Name = "Project #2", Description = LORUM_IPSUM, PartitionKey = GLOBAL_PARTITION_KEY },
            new Project { Name = "Project #3", Description = LORUM_IPSUM, PartitionKey = GLOBAL_PARTITION_KEY },
        };

        private static IEnumerable<Sprint> GetSprints() => new List<Sprint> {
            new Sprint
            { 
                CreatedAt = DateTime.Now,
                ClosingAt = DateTime.Now.AddDays(10),
                PartitionKey = GLOBAL_PARTITION_KEY,
                Statuses = GetDefaultStatuses().ToList(),
                Stories = new List<Story>
                {
                    new Story
                    {
                        Name = "Customer handling",
                        Description = LORUM_IPSUM,
                        PartitionKey = GLOBAL_PARTITION_KEY,
                        Issues = new List<Issue>
                        {
                            new Issue
                            {
                                CreatedAt = DateTime.Now,
                                Description = LORUM_IPSUM,
                                PartitionKey = GLOBAL_PARTITION_KEY,
                                Status = GetDefaultStatuses().ToList().First(),
                                Title = "Customer registration"
                            },
                            new Issue
                            {
                                CreatedAt = DateTime.Now,
                                Description = LORUM_IPSUM,
                                PartitionKey = GLOBAL_PARTITION_KEY,
                                Status = GetDefaultStatuses().ToList().First(),
                                Title = "Customer modifying"
                            },
                            new Issue
                            {
                                CreatedAt = DateTime.Now,
                                Description = LORUM_IPSUM,
                                PartitionKey = GLOBAL_PARTITION_KEY,
                                Status = GetDefaultStatuses().ToList().ElementAt(1),
                                Title = "Authentication"
                            },
                            new Issue
                            {
                                CreatedAt = DateTime.Now,
                                Description = LORUM_IPSUM,
                                PartitionKey = GLOBAL_PARTITION_KEY,
                                Status = GetDefaultStatuses().ToList().Last(),
                                Title = "Customer data model"
                            },
                        }
                    },
                    new Story
                    {
                        Name = "Cash hangling",
                        Description = LORUM_IPSUM,
                        PartitionKey = GLOBAL_PARTITION_KEY,
                        Issues = new List<Issue>
                        {
                            new Issue
                            {
                                CreatedAt = DateTime.Now,
                                Description = LORUM_IPSUM,
                                PartitionKey = GLOBAL_PARTITION_KEY,
                                Status = GetDefaultStatuses().ToList().First(),
                                Title = "Cash register"
                            },
                            new Issue
                            {
                                CreatedAt = DateTime.Now,
                                Description = LORUM_IPSUM,
                                PartitionKey = GLOBAL_PARTITION_KEY,
                                Status = GetDefaultStatuses().ToList().First(),
                                Title = "Transaction"
                            },
                            new Issue
                            {
                                CreatedAt = DateTime.Now,
                                Description = LORUM_IPSUM,
                                PartitionKey = GLOBAL_PARTITION_KEY,
                                Status = GetDefaultStatuses().ToList().ElementAt(1),
                                Title = "Cards handling"
                            },
                            new Issue
                            {
                                CreatedAt = DateTime.Now,
                                Description = LORUM_IPSUM,
                                PartitionKey = GLOBAL_PARTITION_KEY,
                                Status = GetDefaultStatuses().ToList().Last(),
                                Title = "Check the policies"
                            },
                        }
                    }
                }
            },
        };

    }
}
