using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.PostCommand.Delete
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommandRequest, CommandNoMessageResult>
    {
        private readonly IPostWriteRepository _postWriteRepository;
        private readonly IPostReadRepository _postReadRepository;

        public DeletePostCommandHandler(IPostWriteRepository postWriteRepository, IPostReadRepository postReadRepository)
        {
            _postWriteRepository = postWriteRepository;
            _postReadRepository = postReadRepository;
        }

        public async Task<CommandNoMessageResult> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            var post = await _postReadRepository.GetByIdAsync(request.Id);
            _postWriteRepository.Delete(post);

            return new CommandNoMessageResult(204);
        }
    }
}
