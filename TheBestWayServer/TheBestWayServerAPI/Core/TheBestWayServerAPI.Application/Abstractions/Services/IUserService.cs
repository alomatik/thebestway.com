using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.RoleModels;
using TheBestWayServerAPI.Application.ViewModels.UserModels;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CommandWithMessageResult> CreateUserAsync(CreateUserViewModel createUserViewModel);

        Task<CommandNoMessageResult> DeleteUserAsync(int userId);

        Task<CommandNoMessageResult> UpdateUserAsync(UpdateUserViewModel updateUserViewModel);

        Task UpdateRefreshTokenAsync(User user, string? refreshToken,DateTime? refreshTokenExpirationDate);

        Task<QueryResult<UserViewModel>> GetUserAsync(int userId);

        Task<QueryResult<UserRoleViewModel>> GetUserRoleAsync(int userId);
    }
}
