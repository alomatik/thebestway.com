using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels;
using TheBestWayServerAPI.Application.ViewModels.IncludeModels;

namespace TheBestWayServerAPI.Application.Features.Queries.BaseCategoryQueries.GetByIdWCategories
{
    public class GetByIdBaseCategoryWCategoriesQueryRequest:IRequest<PaginatedQueryResult<BaseCategoryWCategoriesViewModel>>
    {
        public int Id { get; set; }

        public int Page { get; set; }
        
        public int PageSize { get; set; }
    }
}
