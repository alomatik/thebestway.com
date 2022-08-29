using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.PostCommand.Update
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest, CommandNoMessageResult>
    {

        private readonly IPostWriteRepository _postWriteRepository;
        private readonly IPostReadRepository _postReadRepository;

        public UpdatePostCommandHandler(IPostWriteRepository postWriteRepository, IPostReadRepository postReadRepository)
        {
            _postWriteRepository = postWriteRepository;
            _postReadRepository = postReadRepository;
        }


        public async Task<CommandNoMessageResult> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {

            var post =await  _postReadRepository.GetByIdAsync(request.Id);
            post.Title = request.Title;
            post.Content = request.Content;
            post.CategoryId = request.CategoryId;
            _postWriteRepository.Update(post);
            //post.ImagePath = request.ImagePath;

            return new CommandNoMessageResult(204);
        }
    }
}
