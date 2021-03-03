using System.Threading.Tasks;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IProjectService
    {
        public Task<Project> CreateAsync(ServiceContext context, Project project);
        public Task<Project> GetProject(ServiceContext context, int projectId);
    }
}
