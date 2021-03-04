using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Entities.Boards;

namespace Timewaster.Web.ViewModels
{
    public class ProjectViewModel
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public Sprint CurrentSprint { get; set; }
        public List<Sprint> Sprints { get; set; } = new List<Sprint>();
        public List<User> Users { get; set; } = new List<User>(); 
    }
}
