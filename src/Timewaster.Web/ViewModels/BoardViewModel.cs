using System.Collections.Generic;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Web.ViewModels
{
    public class BoardViewModel
    {
        public Sprint Sprint { get; set; }
        public IEnumerable<SprintStory> Rows { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
    }
}
