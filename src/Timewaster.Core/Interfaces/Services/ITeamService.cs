using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface ITeamService
    {
        public ValueTask<Team> CreateTeam(ServiceContext context, Team team);
        public ValueTask<Team> UpdateTeam(ServiceContext context, Team team);
        public ValueTask DeleteTeam(ServiceContext context, int teamId);
        public ValueTask<Team> GetTeamById(ServiceContext context, int teamId);
        public ValueTask<IEnumerable<Team>> GetTeams(ServiceContext context);
        public ValueTask AddMemberToTeam(ServiceContext context, int teamId, int userId);
    }
}
