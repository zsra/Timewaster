using System.Collections.Generic;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Core.Entities.Projects
{
    public class Project : Entity
    {
        public string RefernceId { get; set; }
        public string Name { get; set; }

        public ICollection<Sprint> Sprints { get; set; }
    }
}
