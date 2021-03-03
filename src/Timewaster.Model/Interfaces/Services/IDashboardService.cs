using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IDashboardService
    {
        public Task<IReadOnlyList<Project>> GetProjects(ServiceContext context);

        public Task<IReadOnlyList<User>> GetUsers(ServiceContext context);
        public Task<User> GetUser(ServiceContext context, int userId);
    }
}
