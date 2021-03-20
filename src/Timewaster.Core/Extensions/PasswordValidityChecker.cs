using System.Linq;

namespace Timewaster.Core.Extensions
{
    public static class PasswordValidityChecker
    {
		public static int MinimumPasswordLength { get; private set; } = 8;

        public static bool Validate(string password)
		{
			string trimmedPassword = password.Trim();
			return trimmedPassword.Any(char.IsUpper) 
				&& trimmedPassword.Any(char.IsLower) 
				&& trimmedPassword.Any(char.IsDigit) 
				&& trimmedPassword.Length >= MinimumPasswordLength;
		}
	}
}
