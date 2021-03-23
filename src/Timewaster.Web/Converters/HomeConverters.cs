using Timewaster.Core.ValueObjects;
using Timewaster.Web.ViewModels;

namespace Timewaster.Web.Converters
{
    public static class HomeConverters
    {
        #region SignUp converters
        public static SignUpData ViewModelToEntity(this SignUpViewModel viewModel)
        {
            return new SignUpData
            {
               Email = viewModel.Email,
               EmailConfirmed = false,
               Firstname = viewModel.Firstname,
               Lastname = viewModel.Lastname,
               Password = viewModel.Password,
               Username = viewModel.Username
            };
        }
        #endregion
    }
}
