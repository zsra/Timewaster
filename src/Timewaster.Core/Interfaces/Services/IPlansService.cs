using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IPlansService
    {
        public ValueTask<(Sprint, IEnumerable< SprintStory>)> CreatePlan(ServiceContext context);
        public ValueTask<(Sprint, IEnumerable<SprintStory>)> GetSprintPlan(ServiceContext context, int sprintId);
        public ValueTask<Sprint> GetSprint(ServiceContext context, int sprintId);
        public ValueTask<Story> GetStory(ServiceContext context, int storyId);
        public ValueTask<Status> GetStatus(ServiceContext context, int statusId);
        public ValueTask<Story> CreateStory(ServiceContext context, Story story);
        public ValueTask<Issue> CreateIssue(ServiceContext context, Issue issue);
        public ValueTask<Story> UpdateStory(ServiceContext context, Story story);
        public ValueTask<Issue> UpdateIssue(ServiceContext context, Issue issue);
        public ValueTask DeleteSprint(ServiceContext context, int id);
        public ValueTask DeleteStory(ServiceContext context, int id);
        public ValueTask DeleteIssue(ServiceContext context, int id);
        public ValueTask<IEnumerable<Status>> GetDefaultStatuses(ServiceContext context);
        public ValueTask<Issue> AssignUserToIssue(ServiceContext context, int issueId, int userId);
    }
}
