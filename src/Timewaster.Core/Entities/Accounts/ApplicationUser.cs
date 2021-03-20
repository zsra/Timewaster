using Microsoft.AspNetCore.Identity;

namespace Timewaster.Core.Entities.Accounts
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
