using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.UserModels;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CommandWithMessageResult> CreateUserAsync(CreateUserViewModel createUserViewModel)
        {
            User user = new User
            {
                UserName = createUserViewModel.UserName,
                BirthDate = createUserViewModel.BirthDate,
                Email = createUserViewModel.Email,
                Profession = createUserViewModel.Profession,
                CreatedDate = DateTime.Now,
            };

            var identityResult = await _userManager.CreateAsync(user, createUserViewModel.Password);
            if (!identityResult.Succeeded)
                IdentityResultError(identityResult);
            return new CommandWithMessageResult(201, $"Added user {user.Id} ID successfully.");
        }

        public async Task<CommandNoMessageResult> DeleteUserAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            var identityResult = await _userManager.DeleteAsync(user);

            if (!identityResult.Succeeded)
                IdentityResultError(identityResult);
            return new CommandNoMessageResult(204);
        }

        public async Task<CommandNoMessageResult> UpdateUserAsync(UpdateUserViewModel updateUserViewModel)
        {
            var user = await _userManager.FindByIdAsync(updateUserViewModel.Id.ToString());
            user.Profession = updateUserViewModel.Profession;
            user.BirthDate = updateUserViewModel.BirthDate;
            user.Country = updateUserViewModel.Country;
            user.City = updateUserViewModel.City;
            user.TwitterLink = updateUserViewModel.TwitterLink;
            user.GitHubLink = updateUserViewModel.GitHubLink;
            user.YouTubeLink = updateUserViewModel.YouTubeLink;
            user.InstagramLink = updateUserViewModel.InstagramLink;
            var identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
                IdentityResultError(identityResult);
            return new CommandNoMessageResult(204);
        }

        public async Task UpdateRefreshTokenAsync(User user, string? refreshToken, DateTime? refreshTokenExpirationDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpirationDate = refreshTokenExpirationDate;
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new NotFoundException("No such user was found.");
            }
        }

        private Exception IdentityResultError(IdentityResult identityResult)
        {
            string errorMessages = String.Empty;
            foreach (var item in identityResult.Errors)
            {
                errorMessages += $"{item.Description} \n";
            }
            throw new IdentityException(errorMessages);
        }

        public async Task<QueryResult<UserViewModel>> GetUserAsync(int userId)
        {
            var userViewModel = await _userManager.Users.Where(u => u.Id == userId).Select(user => new UserViewModel
            {
                ThumbnailPath = user.ThumbnailPath,
                UserName = user.UserName,
                Profession = user.Profession,
                Country = user.Country,
                City = user.City,
                GitHubLink = user.GitHubLink,
                InstagramLink = user.InstagramLink,
                TwitterLink = user.TwitterLink,
                YouTubeLink = user.YouTubeLink
            }).SingleOrDefaultAsync();
            if (userViewModel != null)
                return new QueryResult<UserViewModel>(200, userViewModel);
            throw new NotImplementedException();
        }
    }
}

