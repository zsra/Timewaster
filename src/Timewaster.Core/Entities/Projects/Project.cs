using System;
using System.Collections.Generic;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Core.Entities.Projects
{
    public class Project : Entity
    {
        public int ReferenceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }

        public virtual ICollection<Sprint> Sprints { get; set; }
    }
}
