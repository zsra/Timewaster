using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IPlanService
    {
        public Task<IEnumerable<SprintStory>> CreatePlan(ServiceContext context);
        public Task<IEnumerable<SprintStory>> GetSprintStories(ServiceContext context, int sprintId);
        public Task<Sprint> CreateSprint(ServiceContext context, Sprint sprint);
        public Task<Story> CreateStory(ServiceContext context, Story story);
        public Task<Issue> CreateIssue(ServiceContext context, Issue issue);
        public Task DeleteSprint(ServiceContext context, int id);
        public Task DeleteStory(ServiceContext context, int id);
        public Task DeleteIssue(ServiceContext context, int id);
        public Task<IEnumerable<Status>> GetDefaultStatuses(ServiceContext context);
    }
}
