using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.RoleCommand.Create
{
    public class CreateRoleCommandRequest:IRequest<CommandWithMessageResult>
    { 
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}
