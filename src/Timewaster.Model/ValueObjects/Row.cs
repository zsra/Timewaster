using System.Collections.Generic;
using System.Linq;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Core.ValueObjects
{
    public class Row
    {
        public Story Story { get; set; }
        public IEnumerable<IGrouping<Status, Issue>> GroupOfIssues { get; set; }
    }
}
