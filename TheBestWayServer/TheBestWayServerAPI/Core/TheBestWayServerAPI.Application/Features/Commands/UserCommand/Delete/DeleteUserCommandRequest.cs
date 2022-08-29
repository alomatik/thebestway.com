using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.Delete
{
    public class DeleteUserCommandRequest:IRequest<CommandNoMessageResult>
    {
        public int Id { get; set; }
    }
}
