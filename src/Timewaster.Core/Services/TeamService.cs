using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly IAsyncRepository<Team> _teamRepository;

        private readonly IAppLogger<TeamService> _logger;

        public TeamService(IAsyncRepository<Team> teamRepository, IAppLogger<TeamService> logger)
        {
            _teamRepository = teamRepository;
            _logger = logger;
        }

        public async ValueTask<Team> CreateTeam(ServiceContext context, Team team)
        {
            return await _teamRepository.AddAsync(context, team);
        }

        public async ValueTask DeleteTeam(ServiceContext context, int teamId)
        {
            await _teamRepository.DeleteAsync(context, teamId);
        }

        public async ValueTask<Team> GetTeamById(ServiceContext context, int teamId)
        {
            return await _teamRepository.GetByIdAsync(context, teamId);
        }

        public async ValueTask<IEnumerable<Team>> GetTeams(ServiceContext context)
        {
            return await _teamRepository.ListAllAsync(context);
        }

        public async ValueTask<Team> UpdateTeam(ServiceContext context, Team team)
        {
            return await _teamRepository.UpdateAsync(context, team);
        }
    }
}
