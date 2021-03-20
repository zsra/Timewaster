using System;
using System.Collections.Generic;

namespace Timewaster.Core.Entities.Accounts
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime JoinedAt { get; set; }
        
        public virtual IEnumerable<Team> Team { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string GetFullName() => $"{ApplicationUser?.Firstname} {ApplicationUser?.Lastname}";
    }
}
