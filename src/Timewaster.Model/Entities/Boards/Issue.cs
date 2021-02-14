using System;
using System.Collections.Generic;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Entities.Socials;

namespace Timewaster.Core.Entities.Boards
{
    public class Issue : Entity
    {
        public ulong ReferenceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public ICollection<Tag> Tags { get; set; }
        public ICollection<User> AssignedUser { get; set; }
        public ICollection<Discussion> Discussions { get; set; }
    }
}
