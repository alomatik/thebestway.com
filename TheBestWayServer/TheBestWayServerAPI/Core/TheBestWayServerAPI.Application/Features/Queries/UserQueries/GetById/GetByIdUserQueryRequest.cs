using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.UserModels;

namespace TheBestWayServerAPI.Application.Features.Queries.UserQueries.GetById
{
    public class GetByIdUserQueryRequest:IRequest<QueryResult<UserViewModel>>
    {
        public int Id { get; set; }
    }
}
