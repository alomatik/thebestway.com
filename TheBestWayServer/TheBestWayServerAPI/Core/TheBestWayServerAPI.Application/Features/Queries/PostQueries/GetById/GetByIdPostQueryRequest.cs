using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.PostModels;

namespace TheBestWayServerAPI.Application.Features.Queries.PostQueries.GetById
{
    public class GetByIdPostQueryRequest:IRequest<QueryResult<GetPostViewModel>>
    {
        public int Id { get; set; }
    }
}
