using MediatR;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.SignIn
{
    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommandRequest, CommandWithTokenResult>
    {
        private readonly IAuthService _authService;

        public SignInUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<CommandWithTokenResult> Handle(SignInUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _authService.SignInAsync(new ViewModels.UserModels.SignInUserViewModel
            {
                UserNameorEmail = request.UserNameorEmail,
                Password = request.Password
            });
        }
    }
}
