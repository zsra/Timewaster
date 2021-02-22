using System;
using System.Collections.Generic;
using System.Text;

namespace Timewaster.Core.Entities.Boards
{
    public class Story : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
