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

namespace TheBestWayServerAPI.Application.Features.Commands.CommentCommand.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, CommandWithMessageResult>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;
        private IMapper _mapper;

        public CreateCommentCommandHandler(ICommentWriteRepository commentWriteRepository, IMapper mapper)
        {
            _commentWriteRepository = commentWriteRepository;
            _mapper = mapper;
        }

        public async Task<CommandWithMessageResult> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Comment comment = _mapper.Map<Comment>(request);
            comment.CreatedDate = DateTime.Now;
            int id = await _commentWriteRepository.AddAsync(comment);
            return new CommandWithMessageResult(201, $"Added comment {id} ID successfully.");
        }
    }
}
