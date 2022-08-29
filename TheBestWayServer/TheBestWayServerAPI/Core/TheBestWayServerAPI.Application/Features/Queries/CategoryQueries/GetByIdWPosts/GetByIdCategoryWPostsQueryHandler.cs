using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels;
using TheBestWayServerAPI.Application.ViewModels.IncludeModels;
using TheBestWayServerAPI.Application.ViewModels.PostModels;

namespace TheBestWayServerAPI.Application.Features.Queries.CategoryQueries.GetByIdWPosts
{
    public class GetByIdCategoryWPostsQueryHandler
        : IRequestHandler<GetByIdCategoryWPostsQueryRequest, PaginatedQueryResult<CategoryWPostsViewModel>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IPostReadRepository _postReadRepository;

        public GetByIdCategoryWPostsQueryHandler(ICategoryReadRepository categoryReadRepository, IPostReadRepository postReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _postReadRepository = postReadRepository;
        }

        public async Task<PaginatedQueryResult<CategoryWPostsViewModel>> Handle(GetByIdCategoryWPostsQueryRequest request, CancellationToken cancellationToken)
        {
            int totalPostCountForCategoryId = await _postReadRepository.CountAsync(p => p.CategoryId == request.Id && !p.IsDeleted);

            var categoryWPostsViewModel = await _categoryReadRepository.GetAsQueryable(c => c.Id == request.Id).Select(category => new CategoryWPostsViewModel
            {
                BaseCategoryId = category.BaseCategoryId,
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Posts = category.Posts.Where(p => !p.IsDeleted).Select(post => new ViewModels.PostModels.PostForCategoryViewModel
                {
                    CategoryId = category.Id,
                    Id = post.Id,
                    Title = post.Title,
                    CreatedDate = post.CreatedDate,
                }).OrderByDescending(pfc => pfc.CreatedDate).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList(),
            }).SingleOrDefaultAsync(cancellationToken);

            return new PaginatedQueryResult<CategoryWPostsViewModel>(200, categoryWPostsViewModel, new Pagination
            {
                CurrentPage = request.Page,
                PageSize = request.PageSize,
                TotalCount = totalPostCountForCategoryId
            });
        }
    }
}
