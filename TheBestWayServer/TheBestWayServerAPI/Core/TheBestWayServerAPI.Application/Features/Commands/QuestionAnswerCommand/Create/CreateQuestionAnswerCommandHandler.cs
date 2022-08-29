using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Commands.QuestionAnswerCommand.Create
{
    public class CreateQuestionAnswerCommandHandler : IRequestHandler<CreateQuestionAnswerCommandRequest, CommandWithMessageResult>
    {
        private readonly IQuestionAnswerWriteRepository _questionAnswerWriteRepository;

        public CreateQuestionAnswerCommandHandler(IQuestionAnswerWriteRepository questionAnswerWriteRepository)
        {
            _questionAnswerWriteRepository = questionAnswerWriteRepository;
        }

        public async Task<CommandWithMessageResult> Handle(CreateQuestionAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var questionAnswer = new QuestionAnswer()
            {
                Content = request.Content,
                UserId = request.UserId,
                QuestionId = request.QuestionId
            };
            questionAnswer.CreatedDate = DateTime.Now;
            int id = await _questionAnswerWriteRepository.AddAsync(questionAnswer);
            return new CommandWithMessageResult(201, $"Added questionanswer {id} ID successfully.");
        }
    }
}
