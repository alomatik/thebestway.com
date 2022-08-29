using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Validations.IdentityValidations
{
    public class CustomUserValidator : IUserValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            int userAge = GetAge(user);

            if (userAge<18)
            {
                IdentityError identityError = new IdentityError
                {
                    Code = "InsufficientAge",
                    Description = "You must be over 18 years old."
                };
                return Task.FromResult(IdentityResult.Failed(identityError));
            }
            return Task.FromResult(IdentityResult.Success);
        }

        private int GetAge(User user)
        {
            DateTime today = DateTime.Today;

            int a = (today.Year * 100 + today.Month) * 100 + today.Day;
            int b = (user.BirthDate.Value.Year * 100 + user.BirthDate.Value.Month) * 100 + user.BirthDate.Value.Day;

            return (a - b) / 10000;
        }
    }
}
