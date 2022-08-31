using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.RoleCommand.AssignRole
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommandRequest, Result>
    {
        private readonly IAuthService _authService;

        public AssignRoleCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(AssignRoleCommandRequest request, CancellationToken cancellationToken)
        {
            return await _authService.AssignRoleAsync(request.UserId, request.AssignRoleViewModels);
        }
    }
}
