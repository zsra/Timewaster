using System.ComponentModel.DataAnnotations;
using Timewaster.Core.Extensions;

namespace Timewaster.Web.ViewModels
{
    public class SignUpViewModel
    {
        [Required]
        [MaxLength(32)]
        public string Username { get; set; }
        [Required]
        [MaxLength(32)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(32)]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordValidation]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
        public string RePassword { get; set; }
    }
}
