using System;

namespace Timewaster.Core.Entities.Accounts
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime JoinedAt { get; set; }
        public virtual Team Team { get; set; }
    }
}
