using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IAsyncRepository<User> _userRepository;
        
        private readonly IAppLogger<ProjectService> _logger;

        public ProjectService(IAsyncRepository<Project> projectRepository, IAsyncRepository<User> userRepository, IAppLogger<ProjectService> logger)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async ValueTask<Project> CreateAsync(ServiceContext context, Project project)
        {
            return await _projectRepository.AddAsync(context, project);
        }

        public async ValueTask<Sprint> GetCurrentSprint(ServiceContext context, int projectId)
        {
            Project project = await _projectRepository.GetByIdAsync(context, projectId);
            return project.Sprints.Last();
        }

        public async ValueTask<Project> GetProject(ServiceContext context, int projectId)
        {
            Project project = await _projectRepository.GetByIdAsync(context, projectId);
            project.Sprints.OrderByDescending(s => s.CreatedAt);
            return project;
        }

        public async ValueTask<User> GetUser(ServiceContext context, int userId)
        {
            return await _userRepository.GetByIdAsync(context, userId);
        }

        public async ValueTask<IReadOnlyList<User>> GetUsers(ServiceContext context)
        {
            return await _userRepository.ListAllAsync(context);
        }
    }
}
