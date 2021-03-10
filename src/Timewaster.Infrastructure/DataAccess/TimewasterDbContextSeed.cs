using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Infrastructure.DataAccess
{
    public class TimewasterDbContextSeed
    {
        private static readonly string GLOBAL_PARTITION_KEY = "PK_GLOBAL";

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
    }
}
