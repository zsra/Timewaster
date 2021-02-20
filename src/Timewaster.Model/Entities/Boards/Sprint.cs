using System;
using System.Collections.Generic;
using Timewaster.Core.Entities.Projects;

namespace Timewaster.Core.Entities.Boards
{
    public class Sprint : Entity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ClosingAt { get; set; }
        public string ReferenceKey { get; set; }

        public ICollection<Column> Columns { get; set; }
    }
}
