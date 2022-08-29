using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Validations.IdentityValidations
{
    public class CustomPasswordValidator : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                IdentityError identityError = new IdentityError()
                {
                    Code = "PasswordContainsUserName",
                    Description = "Passwords cannot contain username."
                };
                return Task.FromResult(IdentityResult.Failed(identityError));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
