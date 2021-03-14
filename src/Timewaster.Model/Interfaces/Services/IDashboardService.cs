using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IDashboardService
    {
        public ValueTask<IReadOnlyList<Project>> GetProjects(ServiceContext context);
    }
}
