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
using TheBestWayServerAPI.Application.ViewModels.PostModels;

namespace TheBestWayServerAPI.Application.Features.Queries.PostQueries.GetAllByCategoryId
{
    public class GetAllByCategoryIdPostQueryHandler : IRequestHandler<GetAllByCategoryIdPostQueryRequest, PaginatedQueryResult<List<GetAllPostViewModel>>>
    {

        private readonly IPostReadRepository _postReadRepository;

        public GetAllByCategoryIdPostQueryHandler(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;
        }

        public async Task<PaginatedQueryResult<List<GetAllPostViewModel>>> Handle(GetAllByCategoryIdPostQueryRequest request, CancellationToken cancellationToken)
        {
            int totalPostCountForCategoryId = await _postReadRepository.CountAsync(p => p.CategoryId == request.CategoryId);

            if (totalPostCountForCategoryId >= 1)
            {
                var getAllPostViewModel = await _postReadRepository.GetAll(p => p.CategoryId == request.CategoryId).Select(post => new GetAllPostViewModel
                {
                    CategoryId = post.CategoryId,
                    Id = post.Id,
                    Title = post.Title,
                    Content = $"{post.Content.Substring(0, 10)}...",
                    CreatedDate = post.CreatedDate,
                    UserId = post.UserId
                }).OrderByDescending(p => p.CreatedDate).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);

                return new PaginatedQueryResult<List<GetAllPostViewModel>>(200, getAllPostViewModel, new ViewModels.Pagination
                {
                    CurrentPage = request.Page,
                    PageSize = request.PageSize,
                    TotalCount = totalPostCountForCategoryId
                });
            }
            throw new NotFoundException("Not found post");

        }
    }
}
