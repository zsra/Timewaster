using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class PlanService : IPlanService
    {
        public Task<Story> AddStoryToSprint(ServiceContext context, string sprintId, Story story)
        {
            throw new NotImplementedException();
        }
    }
}
