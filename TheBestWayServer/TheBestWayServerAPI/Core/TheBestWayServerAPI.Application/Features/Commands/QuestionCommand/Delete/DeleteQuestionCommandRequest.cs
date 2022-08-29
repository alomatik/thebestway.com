using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.QuestionCommand.Delete
{
    public class DeleteQuestionCommandRequest : IRequest<CommandNoMessageResult>
    {
        public int Id { get; set; }
    }
}
