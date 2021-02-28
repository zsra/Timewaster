using System.Collections.Generic;
using System.Linq;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Interfaces.Extensions;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Extensions
{
    public class RowBuilder : IRowBuilder
    {
        public Story Story { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<Issue> Issues { get; set; }

        public Row GetResult() => new Row { Story = Story, GroupOfIssues = GetGroupOfIssues() };

        private IEnumerable<IGrouping<Status, Issue>> GetGroupOfIssues() => Issues.GroupBy(issue => issue.Status);
    }
}
