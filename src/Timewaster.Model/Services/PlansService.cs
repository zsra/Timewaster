using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Extensions;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class PlansService : IPlansService
    {
        private readonly IAsyncRepository<Story> _storyRepository;
        private readonly IAsyncRepository<Issue> _issueRepository;
        private readonly IAsyncRepository<Sprint> _sprintRepository;
        private readonly IAsyncRepository<Status> _statusRepository;

        private readonly IAppLogger<PlansService> _logger;

        public PlansService(IAsyncRepository<Story> storyRepository, 
            IAsyncRepository<Issue> issueRepository, IAsyncRepository<Sprint> sprintRepository, 
            IAsyncRepository<Status> statusRepository, IAppLogger<PlansService> logger)
        {
            _storyRepository = storyRepository;
            _issueRepository = issueRepository;
            _sprintRepository = sprintRepository;
            _statusRepository = statusRepository;
            _logger = logger;
        }

        public async ValueTask<Story> AssignSprintToStory(ServiceContext context, Story story, int sprintId)
        {
            story.Sprint = await _sprintRepository.GetByIdAsync(context, sprintId);
            return story;
        }

        public async ValueTask<Issue> CreateIssue(ServiceContext context, Issue issue)
        {
            return await _issueRepository.AddAsync(context, issue);
        }

        public async ValueTask<(Sprint, IEnumerable<SprintStory>)> CreatePlan(ServiceContext context)
        {
            IEnumerable<Status> statuses = await _statusRepository.ListAllAsync(context);
            Sprint sprint = await _sprintRepository.AddAsync(context, GetNewSprint(context, statuses));

            SprintStoryBuilder builder = new SprintStoryBuilder();
            SprintStoryDirector director = new SprintStoryDirector(builder);
            Collection<SprintStory> sprintStories = new Collection<SprintStory>();

            director.Construct(null, sprint.Statuses, sprint.Issues);
            sprintStories.Add(builder.GetResult());

            return (sprint, sprintStories);
        }

        public async ValueTask<Sprint> CreateSprint(ServiceContext context, Sprint sprint)
        {
            return await _sprintRepository.AddAsync(context, sprint);
        }

        public async ValueTask<Story> CreateStory(ServiceContext context, Story story)
        {
            return await _storyRepository.AddAsync(context, story);
        }

        public async ValueTask DeleteIssue(ServiceContext context, int id)
        {
            Issue issue = await _issueRepository.GetByIdAsync(context, id);
            await _issueRepository.DeleteAsync(context, issue);
        }

        public async ValueTask DeleteSprint(ServiceContext context, int id)
        {
            Sprint sprint = await _sprintRepository.GetByIdAsync(context, id);
            await _sprintRepository.DeleteAsync(context, sprint);
        }

        public async ValueTask DeleteStory(ServiceContext context, int id)
        {
            Story story = await _storyRepository.GetByIdAsync(context, id);
            await _storyRepository.DeleteAsync(context, story);
        }

        public async ValueTask<IEnumerable<Status>> GetDefaultStatuses(ServiceContext context)
        {
            return new List<Status>(await _statusRepository.ListAllAsync(context))
                .Where(s => s.PartitionKey == "PK_GLOBAL");
        }

        public async ValueTask<(Sprint, IEnumerable<SprintStory>)> GetSprint(ServiceContext context, int sprintId)
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

            return (sprint, sprintStories);
        }

        public async ValueTask<Issue> UpdateIssue(ServiceContext context, Issue issue)
        {
            return await _issueRepository.UpdateAsync(context, issue);
        }

        public async ValueTask<Story> UpdateStory(ServiceContext context, Story story)
        {
            return await _storyRepository.UpdateAsync(context, story);
        }

        private Sprint GetNewSprint(ServiceContext context, IEnumerable<Status> statuses) => new Sprint
        {
            CreatedAt = DateTime.Now,
            ClosingAt = DateTime.Now.AddDays(10),
            Statuses = new List<Status>(statuses.Where(s => s.PartitionKey == "PK_GLOBAL")),
            Issues = new List<Issue>(),
            Stories = new List<Story>(),
            PartitionKey = context.ContextId
        };
    }
}
