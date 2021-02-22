using System.Collections.Generic;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class BoardService : IBoardService
    {
        private readonly IAsyncRepository<Sprint> _sprintRepository;   
        private readonly IAppLogger<BoardService> _logger;

        public BoardService(IAsyncRepository<Sprint> sprintRepository, IAppLogger<BoardService> logger)
        {
            _sprintRepository = sprintRepository;
            _logger = logger;
        }

        public IEnumerable<Row> GetRows()
        {
            throw new System.NotImplementedException();
        }
    }
}
