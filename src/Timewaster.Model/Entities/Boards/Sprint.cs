using System;
using System.Collections.Generic;
using Timewaster.Core.Entities.Socials;

namespace Timewaster.Core.Entities.Boards
{
    public class Sprint : Entity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ClosingAt { get; set; }
        public int ReferenceKey { get; set; }

        public virtual Discussion Discussion { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<Status> Statuses { get; set; }
    }
}
