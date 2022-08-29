using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.PostModels;

namespace TheBestWayServerAPI.Application.Features.Queries.PostQueries.GetAllByCategoryId
{
    public class GetAllByCategoryIdPostQueryRequest:IRequest<PaginatedQueryResult<List<GetAllPostViewModel>>>
    {
        public int CategoryId { get; set; }

        public int Page { get; set; }
        
        public int PageSize { get; set; }
    }
}
