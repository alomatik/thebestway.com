using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.BaseCategoryModels;

namespace TheBestWayServerAPI.Application.Features.Queries.BaseCategoryQueries.GetAll
{
    public class GetAllBaseCategoryQueryRequest:IRequest<PaginatedQueryResult<List<GetAllBaseCategoryViewModel>>>
    {
        public int Page { get; set; }
        
        public int PageSize { get; set; }
    }
}
