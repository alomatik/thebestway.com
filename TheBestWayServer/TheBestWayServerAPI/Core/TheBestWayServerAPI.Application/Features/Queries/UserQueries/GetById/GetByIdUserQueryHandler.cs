using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.UserModels;

namespace TheBestWayServerAPI.Application.Features.Queries.UserQueries.GetById
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, QueryResult<UserViewModel>>
    {
        private readonly IUserService _userService;

        public GetByIdUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<QueryResult<UserViewModel>> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserAsync(request.Id);
        }
    }
}
