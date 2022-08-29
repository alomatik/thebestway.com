using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.EmailConfirmation
{
    public class EmailConfirmationUserCommandRequest:IRequest<Result>
    {
        public int UserId { get; set; }
    }

}
