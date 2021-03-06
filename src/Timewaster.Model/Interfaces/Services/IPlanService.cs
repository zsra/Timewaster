using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IPlanService
    {
        public Task<Sprint> CreateSprint(ServiceContext context, Sprint sprint);
        public Task<Story> AddStoryToSprint(ServiceContext context, Story story);
    }
}
