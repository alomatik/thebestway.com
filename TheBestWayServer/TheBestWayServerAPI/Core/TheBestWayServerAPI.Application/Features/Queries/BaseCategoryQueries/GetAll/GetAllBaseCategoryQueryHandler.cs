using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels;
using TheBestWayServerAPI.Application.ViewModels.BaseCategoryModels;

namespace TheBestWayServerAPI.Application.Features.Queries.BaseCategoryQueries.GetAll
{
    public class GetAllBaseCategoryQueryHandler : IRequestHandler<GetAllBaseCategoryQueryRequest, PaginatedQueryResult<List<GetAllBaseCategoryViewModel>>>
    {

        private readonly IBaseCategoryReadRepository _baseCategoryReadRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllBaseCategoryQueryHandler(IBaseCategoryReadRepository baseCategoryReadRepository, ICategoryReadRepository categoryReadRepository)
        {
            _baseCategoryReadRepository = baseCategoryReadRepository;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<PaginatedQueryResult<List<GetAllBaseCategoryViewModel>>> Handle(GetAllBaseCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var count = await _baseCategoryReadRepository.CountAsync();

            var baseCategoryViewModel = await _baseCategoryReadRepository.GetAll().Select(baseCategory => new GetAllBaseCategoryViewModel
            {
                Id = baseCategory.Id,
                Name = baseCategory.Name,
                Description = baseCategory.Description,
                CategoryCount = baseCategory.Categories.Count,
            }).OrderByDescending(bcVM => bcVM.CategoryCount).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);

            return new PaginatedQueryResult<List<GetAllBaseCategoryViewModel>>(200, baseCategoryViewModel, new Pagination
            {
                CurrentPage = request.Page,
                PageSize = request.PageSize,
                TotalCount = count
            });

        }
    }
}
