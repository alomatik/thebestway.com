using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.RoleModels;

namespace TheBestWayServerAPI.Application.Features.Commands.RoleCommand.AssignRole
{
    public class AssignRoleCommandRequest : IRequest<Result>
    {
        public int UserId { get; set; }

        public List<AssignRoleViewModel> AssignRoleViewModels { get; set; }
    }
}
