using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Features.Queries.CommentQueries.GetAllByPostId;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.CommentModels;

namespace TheBestWayServerAPI.Application.Features.Queries.CommentQueries.GetAllByUserId
{
    public class GetAllByUserIdCommentQueryHandler : IRequestHandler<GetAllByUserIdCommentQueryRequest, PaginatedQueryResult<List<CommentForUserViewModel>>>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public GetAllByUserIdCommentQueryHandler(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;
        }

        public async Task<PaginatedQueryResult<List<CommentForUserViewModel>>> Handle(GetAllByUserIdCommentQueryRequest request, CancellationToken cancellationToken)
        {

            int totalCommentCountForUserId = await _commentReadRepository.CountAsync(c => c.UserId == request.UserId && !c.IsDeleted);

            if (totalCommentCountForUserId >= 1)
            {
                var commentViewModels = await _commentReadRepository.GetAll(c => c.UserId == request.UserId && !c.IsDeleted).Select(comment => new CommentForUserViewModel
                {
                    PostId = comment.PostId,
                    Id = comment.Id,
                    Content = comment.Content,
                    CreatedDate = comment.CreatedDate,
                    UserId = comment.UserId,
                    PostTitle = comment.Post.Title
                }).OrderByDescending(c => c.CreatedDate).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);

                return new PaginatedQueryResult<List<CommentForUserViewModel>>(200, commentViewModels, new ViewModels.Pagination
                {
                    CurrentPage = request.Page,
                    PageSize = request.PageSize,
                    TotalCount = totalCommentCountForUserId
                });
            }

            throw new NotFoundException($"No comments found for  user Id {request.UserId}");
        }

    }
}
