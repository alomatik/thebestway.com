using AutoMapper;
using AutoMapper.QueryableExtensions;
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
using TheBestWayServerAPI.Application.ViewModels.CategoryModels;

namespace TheBestWayServerAPI.Application.Features.Queries.CategoryQueries.GetById
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, QueryResult<GetCategoryViewModel>>
    {

        ICategoryReadRepository _categoryReadRepository;
        IMapper _mapper;

        public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<QueryResult<GetCategoryViewModel>> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categoryViewModel = await _categoryReadRepository.GetAsQueryable(c => c.Id == request.Id).ProjectTo<GetCategoryViewModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            if (categoryViewModel != null)
            {
                return new QueryResult<GetCategoryViewModel>(200, categoryViewModel);
            }
            throw new NotFoundException($"{request.Id} category not found.");
        }
    }
}
