using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.CommentCommand.Create
{
    public class CreateCommentCommandRequest : IRequest<CommandWithMessageResult>
    {
        [Required]
        [MaxLength(500)]
        [MinLength(50)]
        public string Content { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }
    }
}
