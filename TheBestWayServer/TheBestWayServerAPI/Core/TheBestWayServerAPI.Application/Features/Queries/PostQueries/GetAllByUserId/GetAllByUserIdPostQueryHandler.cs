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
using TheBestWayServerAPI.Application.ViewModels;
using TheBestWayServerAPI.Application.ViewModels.PostModels;

namespace TheBestWayServerAPI.Application.Features.Queries.PostQueries.GetAll
{
    public class GetAllByUserIdPostQueryHandler : IRequestHandler<GetAllByUserIdPostQueryRequest, PaginatedQueryResult<List<PostForUserViewModel>>>
    {
        private readonly IPostReadRepository _postReadRepository;

        public GetAllByUserIdPostQueryHandler(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;
        }

        public async Task<PaginatedQueryResult<List<PostForUserViewModel>>> Handle(GetAllByUserIdPostQueryRequest request, CancellationToken cancellationToken)
        {

            var totalPostCountForUserId = await _postReadRepository.CountAsync(p => p.UserId == request.UserId);

            if (totalPostCountForUserId >= 1)
            {
                var postForUserViewModels = await _postReadRepository.GetAsQueryable(p => p.UserId == request.UserId).Select(p => new PostForUserViewModel
                {
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content.Substring(0,15),
                    CreatedDate = p.CreatedDate,
                    ModifiedDate = p.ModifiedDate,
                    ViewCount = p.PostDetail.ViewCount,
                    LikeCount = p.PostDetail.LikeCount,
                    DislikeCount = p.PostDetail.DislikeCount,
                    UserId = p.UserId,
                }).OrderByDescending(pfu => pfu.CreatedDate).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);
                return new PaginatedQueryResult<List<PostForUserViewModel>>(200, postForUserViewModels, new Pagination
                {
                    CurrentPage = request.Page,
                    PageSize = request.PageSize,
                    TotalCount = totalPostCountForUserId
                });
            }

            throw new NotFoundException($"Any post not found for {request.UserId} Ids user.");
        }
    }
}
