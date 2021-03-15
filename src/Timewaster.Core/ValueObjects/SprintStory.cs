using System.Collections.Generic;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Core.ValueObjects
{
    public class SprintStory
    {
        public Story Story { get; set; }
        public IEnumerable<(Status, List<Issue>)> GroupOfIssues { get; set; }
    }
}
