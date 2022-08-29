using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.CategoryModels;

namespace TheBestWayServerAPI.Application.Features.Queries.CategoryQueries.GetAllByBaseCategoryId
{
    public class GetAllByBaseCategoryIdCategoryRequest : IRequest<PaginatedQueryResult<List<GetAllCategoryViewModel>>>
    {
        public int BaseCategoryId { get; set; }

        public int Page { get; set; }
        
        public int PageSize { get; set; }
    }
}
