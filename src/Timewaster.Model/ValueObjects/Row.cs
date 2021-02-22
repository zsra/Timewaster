using System.Collections.Generic;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Core.ValueObjects
{
    public class Row
    {
        public Story Story { get; set; }
        public Dictionary<Status, ICollection<Issue>> GroupOfIssues { get; set; } = new Dictionary<Status, ICollection<Issue>>();
    }
}
