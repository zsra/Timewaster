using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IBoardService
    {
        public ValueTask<IEnumerable<SprintStory>> GetSprintStories(ServiceContext context, int sprintId);
        public ValueTask<Project> GetProjectById(ServiceContext context, int id);
        public ValueTask<Issue> GetIssueById(ServiceContext context, int id);
        public ValueTask<Story> GetStoryById(ServiceContext context, int id);
    }
}
