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
using TheBestWayServerAPI.Application.ViewModels.CategoryModels;
using TheBestWayServerAPI.Application.ViewModels.IncludeModels;

namespace TheBestWayServerAPI.Application.Features.Queries.BaseCategoryQueries.GetByIdWCategories
{
    public class GetByIdBaseCategoryWCategoriesQueryHandler :
        IRequestHandler<GetByIdBaseCategoryWCategoriesQueryRequest, PaginatedQueryResult<BaseCategoryWCategoriesViewModel>>
    {

        private readonly IBaseCategoryReadRepository _baseCategoryReadRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetByIdBaseCategoryWCategoriesQueryHandler(IBaseCategoryReadRepository baseCategoryReadRepository, ICategoryReadRepository categoryReadRepository)
        {
            _baseCategoryReadRepository = baseCategoryReadRepository;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<PaginatedQueryResult<BaseCategoryWCategoriesViewModel>> Handle(GetByIdBaseCategoryWCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            int totalCategoryCountForBaseCategoryId = await _categoryReadRepository.CountAsync(c => c.BaseCategoryId == request.Id);

            var baseCategoryWCategoriesViewModels = await _baseCategoryReadRepository.GetAsQueryable(bc => bc.Id == request.Id).Include(bc => bc.Categories).Select(bc => new BaseCategoryWCategoriesViewModel
            {
                Id = bc.Id,
                Name = bc.Name,
                Description = bc.Description,
                TotalCategoryCount = totalCategoryCountForBaseCategoryId,
                Categories = bc.Categories.Select(c => new CategoryForBaseCategoryViewModel
                {
                    BaseCategoryId = bc.Id,
                    Id = c.Id,
                    Name = c.Name,
                    PostCount = c.Posts.Count,
                }).OrderByDescending(cFb => cFb.PostCount).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList()
            }).SingleOrDefaultAsync(bc => bc.Id == request.Id);

            return new PaginatedQueryResult<BaseCategoryWCategoriesViewModel>(200, baseCategoryWCategoriesViewModels, new Pagination
            {
                CurrentPage = request.Page,
                PageSize = request.PageSize,
                TotalCount = totalCategoryCountForBaseCategoryId
            });
        }
    }
}
