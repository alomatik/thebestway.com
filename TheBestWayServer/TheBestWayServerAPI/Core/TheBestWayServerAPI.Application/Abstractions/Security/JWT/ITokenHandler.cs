using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Dtos.Tokens;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Abstractions.Security.JWT
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessTokenAndRefreshToken(User user);
    }
}
