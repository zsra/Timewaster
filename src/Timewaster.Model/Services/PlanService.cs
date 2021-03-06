using System;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class PlanService : IPlanService
    {
        private readonly IAsyncRepository<Story> _storyRepository;
        private readonly IAsyncRepository<Sprint> _sprintRepository;

        private readonly IAppLogger<PlanService> _logger;

        public PlanService(IAsyncRepository<Story> storyRepository, IAsyncRepository<Sprint> sprintRepository, IAppLogger<PlanService> logger)
        {
            _storyRepository = storyRepository;
            _sprintRepository = sprintRepository;
            _logger = logger;
        }

        public async Task<Story> AddStoryToSprint(ServiceContext context, Story story)
        {
            return await _storyRepository.AddAsync(context, story);
        }

        public async Task<Sprint> CreateSprint(ServiceContext context, Sprint sprint)
        {
            return await _sprintRepository.AddAsync(context, sprint);
        }
    }
}
