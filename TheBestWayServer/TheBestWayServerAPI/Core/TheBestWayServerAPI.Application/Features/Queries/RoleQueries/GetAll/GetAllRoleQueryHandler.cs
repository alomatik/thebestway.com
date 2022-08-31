using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.RoleModels;

namespace TheBestWayServerAPI.Application.Features.Queries.RoleQueries.GetAll
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQueryRequest, QueryResult<List<RoleViewModel>>>
    {

        private readonly IRoleService _roleService;

        public GetAllRoleQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<QueryResult<List<RoleViewModel>>> Handle(GetAllRoleQueryRequest request, CancellationToken cancellationToken)
        {
            return await _roleService.GetAllRolesAsync();
        }
    }
}
