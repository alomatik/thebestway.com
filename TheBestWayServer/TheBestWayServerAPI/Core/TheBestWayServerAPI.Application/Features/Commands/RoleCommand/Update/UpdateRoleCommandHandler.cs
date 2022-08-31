using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.RoleCommand.Update
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, CommandNoMessageResult>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CommandNoMessageResult> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            return await _roleService.UpdateRoleAsync(new ViewModels.RoleModels.UpdateRoleViewModel
            {
                Id = request.Id,
                Name = request.Name
            });
        }
    }
}
