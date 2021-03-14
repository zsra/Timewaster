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
        public ValueTask<Project> CreateAsync(ServiceContext context, Project project);
        public ValueTask<Project> GetProject(ServiceContext context, int projectId);
        public ValueTask<Sprint> GetCurrentSprint(ServiceContext context, int projectId);
        public ValueTask<IReadOnlyList<User>> GetUsers(ServiceContext context);
        public ValueTask<User> GetUser(ServiceContext context, int userId);
    }
}
