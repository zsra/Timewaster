﻿using System;
using System.Collections.Generic;
using Timewaster.Core.Entities.Accounts;

namespace Timewaster.Core.Entities.Socials
{
    public class Discussion : Entity
    {
        public DateTimeOffset OpenedAt { get; set; }
        public DateTimeOffset ClosedAt { get; set; }
        public virtual User OpenBy { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
