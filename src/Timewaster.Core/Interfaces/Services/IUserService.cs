using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IUserService
    {
        public ValueTask<User> SignUp(SignUpData signUpData);
        public ValueTask<ServiceContext> SignIn(string email, string password);
        public ValueTask<User> GetUserById(ServiceContext context, int id);
    }
}
