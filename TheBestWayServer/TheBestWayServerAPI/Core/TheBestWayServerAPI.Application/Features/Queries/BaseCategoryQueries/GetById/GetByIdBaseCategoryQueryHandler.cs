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
using TheBestWayServerAPI.Application.ViewModels.BaseCategoryModels;

namespace TheBestWayServerAPI.Application.Features.Queries.BaseCategoryQueries.GetById
{
    public class GetByIdBaseCategoryQueryHandler : IRequestHandler<GetByIdBaseCategoryQueryRequest, QueryResult<GetBaseCategoryViewModel>>
    {

        private readonly IBaseCategoryReadRepository _baseCategoryReadRepository;
        private readonly IMapper _mapper;

        public GetByIdBaseCategoryQueryHandler(IBaseCategoryReadRepository baseCategoryReadRepository, IMapper mapper)
        {
            _baseCategoryReadRepository = baseCategoryReadRepository;
            _mapper = mapper;
        }

        public async Task<QueryResult<GetBaseCategoryViewModel>> Handle(GetByIdBaseCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var baseCategoryViewModel = await _baseCategoryReadRepository.GetAsQueryable(x => x.Id == request.Id).ProjectTo<GetBaseCategoryViewModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            if (baseCategoryViewModel != null)
            {
                return new QueryResult<GetBaseCategoryViewModel>(200, baseCategoryViewModel);
            }
            throw new NotFoundException($"{request.Id} base category not found.");
        }
    }
}
