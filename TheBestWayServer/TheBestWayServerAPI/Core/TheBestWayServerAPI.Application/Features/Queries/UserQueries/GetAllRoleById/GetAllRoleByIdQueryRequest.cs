using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.RoleModels;

namespace TheBestWayServerAPI.Application.Features.Queries.UserQueries.GetAllRoleById
{
    public class GetAllRoleByIdQueryRequest : IRequest<QueryResult<UserRoleViewModel>>
    {
        public int Id { get; set; }
    }
}
