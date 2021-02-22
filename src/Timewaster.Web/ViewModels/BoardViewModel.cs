using System.Collections.Generic;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Web.ViewModels
{
    public class BoardViewModel
    {
        public string ProjectName { get; set; }
        public Sprint Sprint { get; set; }
        public List<Row> Rows { get; set; } = new List<Row>();
    }
}
