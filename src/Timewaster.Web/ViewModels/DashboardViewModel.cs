using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Entities.Projects;

namespace Timewaster.Web.ViewModels
{
    public class DashboardViewModel
    {
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<User> Users { get; set; } = new List<User>();
    }
}
