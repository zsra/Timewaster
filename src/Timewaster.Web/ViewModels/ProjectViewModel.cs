using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Web.ViewModels
{
    public class ProjectViewModel
    {
        public List<Sprint> Sprints { get; set; } = new List<Sprint>();
    }
}
