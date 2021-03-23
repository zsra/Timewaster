using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Timewaster.Core.Extensions
{
	[AttributeUsage(AttributeTargets.All)]
	public class PasswordValidation : ValidationAttribute
	{
		public int MinimumPasswordLength { get; private set; } = 8;

		public override bool IsValid(object value)
		{
			string trimmedPassword = value.ToString().Trim();
			return trimmedPassword.Any(char.IsUpper)
				&& trimmedPassword.Any(char.IsLower)
				&& trimmedPassword.Any(char.IsDigit)
				&& trimmedPassword.Length >= MinimumPasswordLength;
		}
    }
}
