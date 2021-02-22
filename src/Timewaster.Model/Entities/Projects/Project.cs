using System;
using System.Collections.Generic;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Core.Entities.Projects
{
    public class Project : Entity
    {
        public int RefernceId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sprint> Sprints { get; set; }
    }
}
