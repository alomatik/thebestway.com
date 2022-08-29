using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.RabbitMQPublishers;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;
using TheBestWayShared.SharedForWorkerService.Dtos;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.ForgotPassword
{
    public class ForgotPasswordUserCommandHandler : IRequestHandler<ForgotPasswordUserCommandRequest, Result>
    {
        private readonly IAuthService _authService;

        public ForgotPasswordUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(ForgotPasswordUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _authService.FargotPasswordAsync(new ViewModels.UserModels.ForgotPasswordViewModel
            {
                Email = request.Email
            });
        }
    }
}
