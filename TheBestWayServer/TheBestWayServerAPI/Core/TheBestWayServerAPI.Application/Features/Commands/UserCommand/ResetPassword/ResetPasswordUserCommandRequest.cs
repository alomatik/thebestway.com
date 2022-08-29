using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.ResetPassword
{
    public class ResetPasswordUserCommandRequest:IRequest<CommandWithMessageResult>
    {
        [Required]
        public string UserId { get; set; }
    
        [Required]
        public string ResetPasswordToken { get; set; }
        
        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        public string NewPasswordConfirm { get; set; }


    }
}
