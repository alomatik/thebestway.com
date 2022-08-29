using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, CommandNoMessageResult>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CommandNoMessageResult> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteUserAsync(request.Id);
        }
    }
}
