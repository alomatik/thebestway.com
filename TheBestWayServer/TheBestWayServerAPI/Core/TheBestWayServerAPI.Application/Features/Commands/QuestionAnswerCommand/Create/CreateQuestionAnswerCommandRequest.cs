using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.QuestionAnswerCommand.Create
{
    public class CreateQuestionAnswerCommandRequest : IRequest<CommandWithMessageResult>
    {
        [Required]
        [MaxLength(500)]
        [MinLength(3)]
        public string? Content { get; set; }

        public int QuestionId { get; set; }

        public int? UserId { get; set; }
    }
}
