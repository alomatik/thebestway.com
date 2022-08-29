using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.UserModels;

namespace TheBestWayServerAPI.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<CommandWithTokenResult> SignInAsync(SignInUserViewModel signInUserViewModel);

        Task<CommandWithTokenResult> SignInByRefreshTokenAsync(string refreshToken);

        Task<CommandWithMessageResult> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel);

        Task<CommandWithMessageResult> FargotPasswordAsync(ForgotPasswordViewModel forgotPasswordViewModel);

        Task<CommandWithMessageResult> ResetPasswordAsync(ResetPasswordViewModel resetPasswordViewModel);

    }

}
