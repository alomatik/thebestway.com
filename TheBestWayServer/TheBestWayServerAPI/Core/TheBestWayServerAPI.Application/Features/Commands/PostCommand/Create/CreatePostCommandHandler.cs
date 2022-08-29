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

namespace TheBestWayServerAPI.Application.Features.Commands.PostCommand.Create
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, CommandWithMessageResult>
    {

        IPostWriteRepository _postWriteRepository;
        IMapper _mapper;

        public CreatePostCommandHandler(IPostWriteRepository postWriteRepository, IMapper mapper)
        {
            _postWriteRepository = postWriteRepository;
            _mapper = mapper;
        }

        public async Task<CommandWithMessageResult> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);
            post.CreatedDate=DateTime.Now;
            int id = await _postWriteRepository.AddAsync(post);
            return new CommandWithMessageResult(201, $"Added post with {id} IDs successfully.");
        }
    }
}
