using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IAppLogger<TeamService> _logger;

        public UserService(UserManager<ApplicationUser> userManager, IAsyncRepository<User> userRepository, IAppLogger<TeamService> logger)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async ValueTask<User> GetUserById(ServiceContext context, int id)
        {
            return await _userRepository.GetByIdAsync(context, id);
        }

        public async ValueTask<ServiceContext> SignIn(string email, string password)
        {
            IEnumerable<User> users = await _userRepository.ListAllAsync(default);
            //User user = users.FirstOrDefault( u => u.Email == email)
            throw new NotImplementedException();
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
        public async ValueTask<User> SignUp(SignUpData signUpData)
        {
            ApplicationUser applicationUser = GetApplicationUser(signUpData);
           
            IdentityResult userCreationResult = await _userManager.CreateAsync(applicationUser, signUpData.Password);
            if (userCreationResult.Succeeded == false)
            {

            }
            
            User user = GetUser(signUpData, applicationUser);
            
            return await _userRepository.AddAsync(default, user);
        }

        private User GetUser(SignUpData signUpData, ApplicationUser applicationUser) => new User
        {
            ApplicationUser = applicationUser,
            JoinedAt = DateTime.Now,
            PartitionKey = Guid.NewGuid().ToString(),
            Username = signUpData.Username,
        };

        private ApplicationUser GetApplicationUser(SignUpData signUpData) => new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = signUpData.Email,
            UserName = signUpData.Username,
            Firstname = signUpData.Firstname,
            Lastname = signUpData.Lastname,
            EmailConfirmed = false,
        };
    }
}
