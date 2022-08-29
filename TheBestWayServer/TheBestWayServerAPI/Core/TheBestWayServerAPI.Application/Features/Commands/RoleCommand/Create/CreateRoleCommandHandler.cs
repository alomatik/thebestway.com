using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Commands.RoleCommand.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CommandWithMessageResult>
    {
        private readonly RoleManager<Role> _roleManager;

        public CreateRoleCommandHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<CommandWithMessageResult> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            Role role = new Role
            {
                Name = request.Name,
            };

            var identityResult= await _roleManager.CreateAsync(role);

            if (!identityResult.Succeeded)
            {
                var messages = String.Empty;
                foreach (var item in identityResult.Errors)
                {
                    messages += $"{item.Description} \n";
                }
                throw new IdentityException(messages);
            }

            return new CommandWithMessageResult(201, $"Created role {role.Id} ID successfully.");
        }
    }
}
