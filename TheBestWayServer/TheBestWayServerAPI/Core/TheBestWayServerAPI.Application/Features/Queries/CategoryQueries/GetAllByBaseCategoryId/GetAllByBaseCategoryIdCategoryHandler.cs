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
using TheBestWayServerAPI.Application.ViewModels.BaseCategoryModels;
using TheBestWayServerAPI.Application.ViewModels.CategoryModels;

namespace TheBestWayServerAPI.Application.Features.Queries.CategoryQueries.GetAllByBaseCategoryId
{
    public class GetAllByBaseCategoryIdCategoryHandler : IRequestHandler<GetAllByBaseCategoryIdCategoryRequest, PaginatedQueryResult<List<GetAllCategoryViewModel>>>
    {

        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllByBaseCategoryIdCategoryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<PaginatedQueryResult<List<GetAllCategoryViewModel>>> Handle(GetAllByBaseCategoryIdCategoryRequest request, CancellationToken cancellationToken)
        {
            int totalCategoryCountForBaseCategoryId = await _categoryReadRepository.CountAsync(c => c.BaseCategoryId == request.BaseCategoryId);

            if (totalCategoryCountForBaseCategoryId >= 1)
            {
                var getAllCategoryViewModels = await _categoryReadRepository.GetAll(c => c.BaseCategoryId == request.BaseCategoryId).Select(category => new GetAllCategoryViewModel
                {
                    BaseCategoryId = category.BaseCategoryId,
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    PostCount = category.Posts.Count
                }).OrderByDescending(c => c.PostCount).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);
                return new PaginatedQueryResult<List<GetAllCategoryViewModel>>(200, getAllCategoryViewModels, new ViewModels.Pagination
                {
                    CurrentPage = request.Page,
                    PageSize = request.PageSize,
                    TotalCount = totalCategoryCountForBaseCategoryId
                });

            }
            throw new NotFoundException("Not found category");
        }
    }
}
