using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.Dtos.Tokens
{
    public class TokenDto
    {
        public string AccessToken { get; set; }

        public DateTime AccessTokenExpirationDate { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpirationDate { get; set; }
    }
}
