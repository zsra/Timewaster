using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IDashboardService
    {
        public Task<Project> CreateProjectAsync(ServiceContext context, Project project);
        public Task<IReadOnlyList<Project>> GetProjects(ServiceContext context);
        public Task<Project> GetProject(ServiceContext context, int projectId);
    }
}
