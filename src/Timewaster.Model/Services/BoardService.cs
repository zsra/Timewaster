using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class BoardService : IBoardService
    {
        private readonly IAsyncRepository<Sprint> _sprintRepository;
        private readonly IAsyncRepository<Issue> _issueRepository;
        private readonly IAsyncRepository<Story> _storyRepository;
        
        private readonly IAppLogger<BoardService> _logger;

        public BoardService(IAsyncRepository<Sprint> sprintRepository, IAsyncRepository<Issue> issueRepository,
            IAsyncRepository<Story> storyRepository, IAppLogger<BoardService> logger)
        {
            _sprintRepository = sprintRepository;
            _issueRepository = issueRepository;
            _storyRepository = storyRepository;
            _logger = logger;
        }

        public async Task<Issue> GetIssueById(ServiceContext context, int id)
        {
            return await _issueRepository.GetByIdAsync(context, id);
        }

        public Task<IEnumerable<Row>> GetRows(ServiceContext context, int sprintId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Story> GetStoryById(ServiceContext context, int id)
        {
            return await _storyRepository.GetByIdAsync(context, id);
        }
    }
}
