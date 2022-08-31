using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Commands.RoleCommand.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CommandWithMessageResult>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CommandWithMessageResult> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {

            return await _roleService.CreateRoleAsync(new ViewModels.RoleModels.CreateRoleViewModel
            {
                Name = request.Name
            });
        }
    }
}
