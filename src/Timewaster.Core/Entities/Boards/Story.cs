using System;
using System.Collections.Generic;
using System.Text;
using Timewaster.Core.Entities.Socials;

namespace Timewaster.Core.Entities.Boards
{
    public class Story : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsClosed { get; set; }

        public virtual Sprint Sprint { get; set; }
        public virtual Discussion Discussion { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
