using System.Collections.Generic;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Core.Entities.Projects
{
    public class Column : Entity
    {
        public string Title { get; set; }
        public ICollection<Issue> Issues { get; set; }
    }
}
