using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IBoardService
    {
        public Task<IEnumerable<SprintStory>> GetSprintStories(ServiceContext context, int sprintId);
        public Task<Project> GetProjectById(ServiceContext context, int id);
        public Task<Issue> GetIssueById(ServiceContext context, int id);
        public Task<Story> GetStoryById(ServiceContext context, int id);
    }
}
