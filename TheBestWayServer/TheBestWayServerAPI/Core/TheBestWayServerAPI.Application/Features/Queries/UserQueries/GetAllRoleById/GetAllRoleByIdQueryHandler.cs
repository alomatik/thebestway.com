using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.RoleModels;

namespace TheBestWayServerAPI.Application.Features.Queries.UserQueries.GetAllRoleById
{
    public class GetAllRoleByIdQueryHandler : IRequestHandler<GetAllRoleByIdQueryRequest, QueryResult<UserRoleViewModel>>
    {
        private readonly IUserService _userService;

        public GetAllRoleByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<QueryResult<UserRoleViewModel>> Handle(GetAllRoleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserRoleAsync(request.Id);
        }
    }
}
