using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.CommentModels;

namespace TheBestWayServerAPI.Application.Features.Queries.CommentQueries.GetAllByPostId
{
    public class GetAllByPostIdCommentQueryHandler : IRequestHandler<GetAllByPostIdCommentQueryRequest, PaginatedQueryResult<List<CommentViewModel>>>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public GetAllByPostIdCommentQueryHandler(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;
        }

        public async Task<PaginatedQueryResult<List<CommentViewModel>>> Handle(GetAllByPostIdCommentQueryRequest request, CancellationToken cancellationToken)
        {

            int totalCommentCountForPostId = await _commentReadRepository.CountAsync(c => c.PostId == request.PostId && !c.IsDeleted);

            if (totalCommentCountForPostId >= 1)
            {
                var commentViewModels = await _commentReadRepository.GetAll(c => c.PostId == request.PostId && !c.IsDeleted).Select(comment => new CommentViewModel
                {
                    PostId = comment.PostId,
                    Id = comment.Id,
                    Content = comment.Content,
                    CreatedDate = comment.CreatedDate,
                    UserId = comment.UserId,
                    UserName = comment.User.UserName
                }).OrderByDescending(c => c.CreatedDate).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);

                return new PaginatedQueryResult<List<CommentViewModel>>(200, commentViewModels, new ViewModels.Pagination
                {
                    CurrentPage = request.Page,
                    PageSize = request.PageSize,
                    TotalCount = totalCommentCountForPostId
                });
            }

            throw new NotFoundException($"No comments found for  post Id {request.PostId}");

        }
    }
}
