using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.PostCommand.Delete
{
    public class DeletePostCommandRequest:IRequest<CommandNoMessageResult>
    {
        public int Id { get; set; }
    }
}
