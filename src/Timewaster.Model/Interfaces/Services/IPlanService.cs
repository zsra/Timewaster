using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IPlanService
    {
        public Task<Story> AddStoryToSprint(ServiceContext context, string sprintId, Story story);
    }
}
