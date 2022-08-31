using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.RoleCommand.Delete
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, CommandNoMessageResult>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CommandNoMessageResult> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            return await _roleService.DeleteRoleAsync(request.Id);
        }
    }
}
