using System;
using Timewaster.Core.Entities.Accounts;

namespace Timewaster.Core.Entities.Socials
{
    public class Comment : Entity
    {
        public virtual  User CreatedBy { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedAt { get; set; } 
    }
}