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
    public class DeleteQuestionCommandHandler:IRequestHandler<DeleteQuestionCommandRequest, CommandNoMessageResult>
    {
        private readonly IQuestionWriteRepository _questionWriteRepository;
        private readonly IQuestionReadRepository _questionReadRepository;

        public DeleteQuestionCommandHandler(IQuestionWriteRepository questionWriteRepository, IQuestionReadRepository questionReadRepository)
        {
            _questionWriteRepository = questionWriteRepository;
            _questionReadRepository = questionReadRepository;
        }

        public async Task<CommandNoMessageResult> Handle(DeleteQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var question= await _questionReadRepository.GetByIdAsync(request.Id);
            _questionWriteRepository.Delete(question);
            return new CommandNoMessageResult(204);
        }
    }
}
