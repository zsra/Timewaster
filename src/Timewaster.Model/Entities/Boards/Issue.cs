using System;
using System.Collections.Generic;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.Entities.Socials;

namespace Timewaster.Core.Entities.Boards
{
    public class Issue : Entity
    {
        public int ReferenceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public virtual Project Project { get; set; }
        public virtual Sprint Sprint { get; set; }
        public virtual Story Story { get; set; }
        public virtual Issue ParentIssue { get; set; }
        public virtual ICollection<Issue> SubIssues { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<User> AssignedUsers { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
    }
}
