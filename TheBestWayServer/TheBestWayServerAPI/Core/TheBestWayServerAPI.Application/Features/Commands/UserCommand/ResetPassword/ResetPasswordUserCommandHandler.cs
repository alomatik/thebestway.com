using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.ResetPassword
{
    public class ResetPasswordUserCommandHandler : IRequestHandler<ResetPasswordUserCommandRequest, CommandWithMessageResult>
    {
        private readonly IAuthService _authService;

        public ResetPasswordUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<CommandWithMessageResult> Handle(ResetPasswordUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _authService.ResetPasswordAsync(new ViewModels.UserModels.ResetPasswordViewModel
            {
                UserId = request.UserId,
                ResetPasswordToken = request.ResetPasswordToken,
                NewPassword = request.NewPassword,
                NewPasswordConfirm = request.NewPasswordConfirm
            });
        }
    }
}
