using System;
using System.Collections.Generic;
using System.Text;
using Timewaster.Core.Entities.Projects;

namespace Timewaster.Core.Entities.Accounts
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public int ReferenceKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OwnerId { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<Project> Projects { get; set; }
    }
}
