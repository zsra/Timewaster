﻿using System;
using System.Collections.Generic;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Entities.Socials;

namespace Timewaster.Core.Entities.Boards
{
    public class Issue : Entity
    {
        public int ReferenceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public virtual Story Story { get; set; }
        public virtual Status Status { get; set; }
        public virtual Discussion Discussion { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<User> AssignedUsers { get; set; }
      
    }
}
