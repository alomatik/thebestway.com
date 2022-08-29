using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.QuestionAnswerCommand.Delete
{
    public class DeleteQuestionAnswerCommandRequest : IRequest<CommandNoMessageResult>
    {
        public int Id { get; set; }
    }
}
