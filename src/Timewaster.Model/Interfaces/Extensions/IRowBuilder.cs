using System.Collections.Generic;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Extensions
{
    public interface IRowBuilder
    {
        Story Story { get; set; }
        IEnumerable<Status> Statuses { get; set; }
        IEnumerable<Issue> Issues { get; set; }

        Row GetResult();
    }
}
