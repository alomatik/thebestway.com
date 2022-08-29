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

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.ChangePassword
{
    public class ChangePasswordUserCommandHandler : IRequestHandler<ChangePasswordUserCommandRequest, Result>
    {
        private readonly IAuthService _authService;

        public ChangePasswordUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(ChangePasswordUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _authService.ChangePasswordAsync(new ViewModels.UserModels.ChangePasswordViewModel
            {
                UserId = request.UserId,
                CurrentPassword = request.CurrentPassword,
                NewPassword = request.NewPassword,
                NewPasswordConfirm = request.NewPasswordConfirm
            });
        }
    }
}
