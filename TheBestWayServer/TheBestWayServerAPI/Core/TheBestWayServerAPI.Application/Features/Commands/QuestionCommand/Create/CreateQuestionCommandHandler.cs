using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Commands.QuestionCommand.Create
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommandRequest, CommandWithMessageResult>
    {
        private readonly IQuestionWriteRepository _questionWriteRepository;
        private IMapper _mapper;

        public CreateQuestionCommandHandler(IQuestionWriteRepository questionWriteRepository, IMapper mapper)
        {
            _questionWriteRepository = questionWriteRepository;
            _mapper = mapper;
        }

        public async Task<CommandWithMessageResult> Handle(CreateQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            Question question = _mapper.Map<Question>(request);
            question.CreatedDate = DateTime.Now;
            int id = await _questionWriteRepository.AddAsync(question);
            return new CommandWithMessageResult(201, $"Added question {id} ID successfully.");
        }
    }
}
