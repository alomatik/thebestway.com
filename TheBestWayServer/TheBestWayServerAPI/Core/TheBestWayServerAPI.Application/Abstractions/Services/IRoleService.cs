using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.RoleModels;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Abstractions.Services
{
    public interface IRoleService
    {
        //TODO ...
        Task<CommandWithMessageResult> CreateRoleAsync(CreateRoleViewModel createRoleViewModel);

        Task<CommandNoMessageResult> UpdateRoleAsync(UpdateRoleViewModel updateRoleViewModel);

        Task<CommandNoMessageResult> DeleteRoleAsync(int roleId);

        Task<QueryResult<List<RoleViewModel>>> GetAllRolesAsync();
    }
}
