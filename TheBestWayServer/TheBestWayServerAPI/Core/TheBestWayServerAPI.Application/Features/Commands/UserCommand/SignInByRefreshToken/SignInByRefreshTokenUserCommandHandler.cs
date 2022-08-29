using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.SignInByRefreshToken
{
    public class SignInByRefreshTokenUserCommandHandler : IRequestHandler<SignInByRefreshTokenUserCommandRequest, CommandWithTokenResult>
    {
        private readonly IAuthService _authService;

        public SignInByRefreshTokenUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<CommandWithTokenResult> Handle(SignInByRefreshTokenUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _authService.SignInByRefreshTokenAsync(request.RefreshToken);
        }
    }
}
