using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Extensions;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class PlanService : IPlanService
    {
        private readonly IAsyncRepository<Story> _storyRepository;
        private readonly IAsyncRepository<Issue> _issueRepository;
        private readonly IAsyncRepository<Sprint> _sprintRepository;

        private readonly IAppLogger<PlanService> _logger;

        public PlanService(IAsyncRepository<Story> storyRepository, IAsyncRepository<Issue> issueRepository,
            IAsyncRepository<Sprint> sprintRepository, IAppLogger<PlanService> logger)
        {
            _storyRepository = storyRepository;
            _issueRepository = issueRepository;
            _sprintRepository = sprintRepository;
            _logger = logger;
        }

        public async Task<Issue> CreateIssue(ServiceContext context, Issue issue)
        {
            return await _issueRepository.AddAsync(context, issue);
        }

        public async Task<Sprint> CreateSprint(ServiceContext context, Sprint sprint)
        {
            return await _sprintRepository.AddAsync(context, sprint);
        }

        public async Task<Story> CreateStory(ServiceContext context, Story story)
        {
            return await _storyRepository.AddAsync(context, story);
        }

        public async Task DeleteIssue(ServiceContext context, int id)
        {
            Issue issue = await _issueRepository.GetByIdAsync(context, id);
            await _issueRepository.DeleteAsync(context, issue);
        }

        public async Task DeleteSprint(ServiceContext context, int id)
        {
            Sprint sprint = await _sprintRepository.GetByIdAsync(context, id);
            await _sprintRepository.DeleteAsync(context, sprint);
        }

        public async Task DeleteStory(ServiceContext context, int id)
        {
            Story story = await _storyRepository.GetByIdAsync(context, id);
            await _storyRepository.DeleteAsync(context, story);
        }

        public async Task<IEnumerable<SprintStory>> GetSprintStories(ServiceContext context, int sprintId)
        {
            Sprint sprint = await _sprintRepository.GetByIdAsync(context, sprintId);

            SprintStoryBuilder builder = new SprintStoryBuilder();
            SprintStoryDirector director = new SprintStoryDirector(builder);
            Collection<SprintStory> sprintStories = new Collection<SprintStory>();

            foreach (Story story in sprint.Stories)
            {
                director.Construct(story, sprint.Statuses, story.Issues);
                sprintStories.Add(builder.GetResult());
            }

            return sprintStories;
        }
    }
}
