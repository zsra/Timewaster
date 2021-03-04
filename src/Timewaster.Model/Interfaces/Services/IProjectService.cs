using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IProjectService
    {
        public Task<Project> CreateAsync(ServiceContext context, Project project);
        public Task<Project> GetProject(ServiceContext context, int projectId);
        public Task<Sprint> GetCurrentSprint(ServiceContext context, int projectId);
        public Task<IReadOnlyList<User>> GetUsers(ServiceContext context);
        public Task<User> GetUser(ServiceContext context, int userId);
    }
}
