using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.Extensions;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class BoardService : IBoardService
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IAsyncRepository<Sprint> _sprintRepository;
        private readonly IAsyncRepository<Issue> _issueRepository;
        private readonly IAsyncRepository<Story> _storyRepository;
        
        private readonly IAppLogger<BoardService> _logger;

        public BoardService(IAsyncRepository<Project> projectRepository, IAsyncRepository<Sprint> sprintRepository,
            IAsyncRepository<Issue> issueRepository, IAsyncRepository<Story> storyRepository, IAppLogger<BoardService> logger)
        {
            _projectRepository = projectRepository;
            _sprintRepository = sprintRepository;
            _issueRepository = issueRepository;
            _storyRepository = storyRepository;
            _logger = logger;
        }

        public async ValueTask<Issue> GetIssueById(ServiceContext context, int id)
        {
            return await _issueRepository.GetByIdAsync(context, id);
        }

        public async ValueTask<Project> GetProjectById(ServiceContext context, int id)
        {
            return await _projectRepository.GetByIdAsync(context, id);
        }

        public async ValueTask<IEnumerable<SprintStory>> GetSprintStories(ServiceContext context, int sprintId)
        {
            Sprint sprint = await _sprintRepository.GetByIdAsync(context, sprintId);
            
            SprintStoryBuilder builder = new SprintStoryBuilder();
            SprintStoryDirector director = new SprintStoryDirector(builder);
            Collection<SprintStory> sprintStories = new Collection<SprintStory>();

            foreach(Story story in sprint.Stories)
            {
                director.Construct(story, sprint.Statuses, story.Issues);
                sprintStories.Add(builder.GetResult());
            }

            return sprintStories;
        }

        public async ValueTask<Story> GetStoryById(ServiceContext context, int id)
        {
            return await _storyRepository.GetByIdAsync(context, id);
        }
    }
}
