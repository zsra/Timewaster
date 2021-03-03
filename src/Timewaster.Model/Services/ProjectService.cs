using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        
        private readonly IAppLogger<ProjectService> _logger;

        public ProjectService(IAsyncRepository<Project> projectRepository, IAppLogger<ProjectService> logger)
        {
            _projectRepository = projectRepository;
            _logger = logger;
        }

        public async Task<Project> CreateAsync(ServiceContext context, Project project)
        {
            return await _projectRepository.AddAsync(context, project);
        }

        public async Task<Project> GetProject(ServiceContext context, int projectId)
        {
            return await _projectRepository.GetByIdAsync(context, projectId);
        }
    }
}
