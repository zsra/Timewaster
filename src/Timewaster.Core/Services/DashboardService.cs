﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IAsyncRepository<User> _userRepository;

        private readonly IAppLogger<DashboardService> _logger;

        public DashboardService(IAsyncRepository<Project> projectRepository, IAsyncRepository<User> userRepository, IAppLogger<DashboardService> logger)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async ValueTask<IReadOnlyList<Project>> GetProjects(ServiceContext context)
        {
            return await _projectRepository.ListAllAsync(context);
        }
    }
}
