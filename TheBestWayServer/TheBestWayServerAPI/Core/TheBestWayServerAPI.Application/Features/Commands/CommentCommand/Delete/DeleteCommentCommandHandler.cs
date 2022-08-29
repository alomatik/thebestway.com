using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.CommentCommand.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommandRequest, CommandNoMessageResult>
    {

        private readonly ICommentReadRepository _commentReadRepository;
        private readonly ICommentWriteRepository _commentWriteRepository;

        public DeleteCommentCommandHandler(ICommentReadRepository commentReadRepository, ICommentWriteRepository commentWriteRepository)
        {
            _commentReadRepository = commentReadRepository;
            _commentWriteRepository = commentWriteRepository;
        }

        public async Task<CommandNoMessageResult> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var comment = await _commentReadRepository.GetByIdAsync(request.Id);
            _commentWriteRepository.Delete(comment);
            return new CommandNoMessageResult(204);
        }
    }
}
