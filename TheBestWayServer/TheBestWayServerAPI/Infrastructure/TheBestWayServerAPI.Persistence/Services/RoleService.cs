using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.RoleModels;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Persistence.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleService(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<CommandWithMessageResult> CreateRoleAsync(CreateRoleViewModel createRoleViewModel)
        {
            Role role = new Role()
            {
                Name = createRoleViewModel.Name,
            };
            var identityResult = await _roleManager.CreateAsync(role);
            if (!identityResult.Succeeded)
                IdentityResultError(identityResult);

            return new CommandWithMessageResult(201, $"Created role {role.Id} Ids successfuly");
        }

        public async Task<CommandNoMessageResult> UpdateRoleAsync(UpdateRoleViewModel updateRoleViewModel)
        {
            var role = await _roleManager.FindByIdAsync(updateRoleViewModel.Id.ToString());
            role.Name = updateRoleViewModel.Name;
            var identityResult = await _roleManager.UpdateAsync(role);
            if (!identityResult.Succeeded)
                IdentityResultError(identityResult);
            return new CommandNoMessageResult(204);
        }

        public async Task<CommandNoMessageResult> DeleteRoleAsync(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            var identityResult = await _roleManager.DeleteAsync(role);
            if (!identityResult.Succeeded)
                IdentityResultError(identityResult);
            return new CommandNoMessageResult(204);
        }

        public async Task<QueryResult<List<RoleViewModel>>> GetAllRolesAsync()
        {
            var roleViewModels = await _roleManager.Roles.Select(role => new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            }).ToListAsync();

            if (!roleViewModels.Any())
                throw new NotFoundException("Not found any role.");
            return new QueryResult<List<RoleViewModel>>(200, roleViewModels);
        }

        private Exception IdentityResultError(IdentityResult identityResult)
        {
            string errorMessages = String.Empty;
            foreach (var item in identityResult.Errors)
            {
                errorMessages += $"{item.Description} \n";
            }
            throw new IdentityException(errorMessages);
        }
    }
}
