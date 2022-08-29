using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.Create
{
    public class CreateUserCommandRequest : IRequest<CommandWithMessageResult>
    {
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string UserName { get; set; }
       
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Profession { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
