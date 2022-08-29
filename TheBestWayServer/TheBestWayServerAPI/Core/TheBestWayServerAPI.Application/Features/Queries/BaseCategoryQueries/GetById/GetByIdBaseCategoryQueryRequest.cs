using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.BaseCategoryModels;

namespace TheBestWayServerAPI.Application.Features.Queries.BaseCategoryQueries.GetById
{
    public class GetByIdBaseCategoryQueryRequest : IRequest<QueryResult<GetBaseCategoryViewModel>>
    {
        public int Id { get; set; }
    }
}
