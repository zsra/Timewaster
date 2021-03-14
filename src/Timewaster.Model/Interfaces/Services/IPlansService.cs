using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IPlansService
    {
        public ValueTask<(Sprint, IEnumerable< SprintStory>)> CreatePlan(ServiceContext context);
        public ValueTask<(Sprint, IEnumerable<SprintStory>)> GetSprint(ServiceContext context, int sprintId);
        public ValueTask<Story> CreateStory(ServiceContext context, Story story);
        public ValueTask<Story> AssignSprintToStory(ServiceContext context, Story story, int sprintId);
        public ValueTask<Issue> CreateIssue(ServiceContext context, Issue issue);
        public ValueTask<Story> UpdateStory(ServiceContext context, Story story);
        public ValueTask<Issue> UpdateIssue(ServiceContext context, Issue issue);
        public ValueTask DeleteSprint(ServiceContext context, int id);
        public ValueTask DeleteStory(ServiceContext context, int id);
        public ValueTask DeleteIssue(ServiceContext context, int id);
        public ValueTask<IEnumerable<Status>> GetDefaultStatuses(ServiceContext context);
    }
}
