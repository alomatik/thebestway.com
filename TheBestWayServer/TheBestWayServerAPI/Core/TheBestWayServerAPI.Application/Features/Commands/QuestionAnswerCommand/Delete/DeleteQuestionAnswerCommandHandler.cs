using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.QuestionAnswerCommand.Delete
{
    public class DeleteQuestionAnswerCommandHandler : IRequestHandler<DeleteQuestionAnswerCommandRequest, CommandNoMessageResult>
    {
        private readonly IQuestionAnswerWriteRepository _questionAnswerWriteRepository;
        private readonly IQuestionAnswerReadRepository _questionAnsweeReadRepository;

        public DeleteQuestionAnswerCommandHandler(IQuestionAnswerWriteRepository questionAnswerWriteRepository, IQuestionAnswerReadRepository questionAnsweeReadRepository)
        {
            _questionAnswerWriteRepository = questionAnswerWriteRepository;
            _questionAnsweeReadRepository = questionAnsweeReadRepository;
        }

        public async Task<CommandNoMessageResult> Handle(DeleteQuestionAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var questionanswer= await _questionAnsweeReadRepository.GetByIdAsync(request.Id);
            _questionAnswerWriteRepository.Delete(questionanswer);
            return new CommandNoMessageResult(204);
        }
    }
}
