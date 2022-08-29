using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.CategoryModels;

namespace TheBestWayServerAPI.Application.Features.Queries.CategoryQueries.GetById
{
    public class GetByIdCategoryQueryRequest:IRequest<QueryResult<GetCategoryViewModel>>
    {
        public int Id { get; set; }
    }
}
