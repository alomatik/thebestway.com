using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.SignIn
{
    public class SignInUserCommandRequest:IRequest<CommandWithTokenResult>
    {
        [Required]
        public string UserNameorEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
