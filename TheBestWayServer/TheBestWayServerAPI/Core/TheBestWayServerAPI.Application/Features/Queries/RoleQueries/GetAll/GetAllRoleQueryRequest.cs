using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.RoleModels;

namespace TheBestWayServerAPI.Application.Features.Queries.RoleQueries.GetAll
{
    public class GetAllRoleQueryRequest:IRequest<QueryResult<List<RoleViewModel>>>
    {
    }
}
