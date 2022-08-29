using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.RabbitMQPublishers;
using TheBestWayServerAPI.Application.Abstractions.Security.JWT;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Dtos.Tokens;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.UserModels;
using TheBestWayServerAPI.Domain.Entities;
using TheBestWayShared.SharedForWorkerService.Dtos;

namespace TheBestWayServerAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        private readonly IRabbitMQResetPasswordPublisher _rabbitMQResetPasswordPublisher;


        public AuthService(UserManager<User> userManager, ITokenHandler tokenHandler, SignInManager<User> signInManager, IUserService userService, IRabbitMQResetPasswordPublisher rabbitMQResetPasswordPublisher)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userService = userService;
            _rabbitMQResetPasswordPublisher = rabbitMQResetPasswordPublisher;
        }

        public async Task<CommandWithMessageResult> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel)
        {
            var user = await _userManager.FindByIdAsync(changePasswordViewModel.UserId.ToString());
            if (user == null)
                throw new NotFoundException("User not found");
            IdentityResult identityResult = await _userManager.ChangePasswordAsync(user, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);
            if (!identityResult.Succeeded)
                IdentityResultError(identityResult);
            await _userManager.UpdateSecurityStampAsync(user);
            await _userService.UpdateRefreshTokenAsync(user, null, null);
            return new CommandWithMessageResult(200, "The password has been successfully changed and refresh token deleted.");
        }

        public async Task<CommandWithMessageResult> FargotPasswordAsync(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Email);
            if (user == null)
                throw new NotFoundException("No user found with this e-mail.");
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            _rabbitMQResetPasswordPublisher.Publish(new MailandResetPasswordUrlDto
            {
                Mail = forgotPasswordViewModel.Email,
                PasswordResetUrl = $"https://localhost:7135/api/Users/ResetPassword?userId={user.Id}&token={passwordResetToken}"
            });
            return new CommandWithMessageResult(200, "Password reset link will be sent to email in a few minutes.");
        }

        public async Task<CommandWithMessageResult> ResetPasswordAsync(ResetPasswordViewModel resetPasswordViewModel)
        {
            var user = await _userManager.FindByIdAsync(resetPasswordViewModel.UserId);
            var resetPasswordToken = resetPasswordViewModel.ResetPasswordToken.Replace(" ", "+");
            var identityResult = await _userManager.ResetPasswordAsync(user, resetPasswordToken, resetPasswordViewModel.NewPassword);
            if (!identityResult.Succeeded)
                IdentityResultError(identityResult);
            await _userManager.UpdateSecurityStampAsync(user);
            await _userService.UpdateRefreshTokenAsync(user, null, null);
            return new CommandWithMessageResult(200, "The password has been successfully reset.");
        }

        public async Task<CommandWithTokenResult> SignInAsync(SignInUserViewModel signInUserViewModel)
        {
            var user = await _userManager.FindByEmailAsync(signInUserViewModel.UserNameorEmail);
            if (user == null)
                user = await _userManager.FindByNameAsync(signInUserViewModel.UserNameorEmail);
            if (user == null)
                throw new NotFoundException("No such user was found.");
            SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, signInUserViewModel.Password, false);
            if (!signInResult.Succeeded)
                throw new IdentityException("Wrong email or password!");
            TokenDto tokenDto = _tokenHandler.CreateAccessTokenAndRefreshToken(user);
            await _userService.UpdateRefreshTokenAsync(user, tokenDto.RefreshToken, tokenDto.RefreshTokenExpirationDate);

            return new CommandWithTokenResult(200, tokenDto, $"Sucessfuly signin and created access and refresh token for {user.UserName}.");
        }

        public async Task<CommandWithTokenResult> SignInByRefreshTokenAsync(string refreshToken)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.RefreshToken == refreshToken);
            if (user == null)
                throw new NotFoundException("No such user was found");
            if (user.RefreshTokenExpirationDate < DateTime.UtcNow)
                throw new IdentityException("Refresh token expired");
            TokenDto tokenDto = _tokenHandler.CreateAccessTokenAndRefreshToken(user);
            await _userService.UpdateRefreshTokenAsync(user, tokenDto.RefreshToken, tokenDto.RefreshTokenExpirationDate);

            return new CommandWithTokenResult(200, tokenDto, $"Sucessfuly signin and created access and refresh token by {refreshToken} for {user.UserName}.");

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
    }



}
