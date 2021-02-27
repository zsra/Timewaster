using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IAsyncRepository<Project> _projectRepository;

        private readonly IAppLogger<DashboardService> _logger;

        public DashboardService(IAsyncRepository<Project> projectRepository, IAppLogger<DashboardService> logger)
        {
            _projectRepository = projectRepository;
            _logger = logger;
        }

        public async Task<Project> CreateProjectAsync(ServiceContext context, Project project)
        {
            return await _projectRepository.AddAsync(context, project);
        }

        public async Task<Project> GetProject(ServiceContext context, int projectId)
        {
            return await _projectRepository.GetByIdAsync(context, projectId);
        }

        public async Task<IReadOnlyList<Project>> GetProjects(ServiceContext context)
        {
            return await _projectRepository.ListAllAsync(context);
        }
    }
}
