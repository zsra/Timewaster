using Timewaster.Core.Entities.Projects;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;

namespace Timewaster.Core.Services
{
    public class BoardService : IBoardService
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IAppLogger<BoardService> _logger;

        public BoardService(IAsyncRepository<Project> projectRepository, IAppLogger<BoardService> logger)
        {
            _projectRepository = projectRepository;
            _logger = logger;
        }
    }
}
