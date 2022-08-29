using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Dtos.Tokens;

namespace TheBestWayServerAPI.Application.Results
{
    public class CommandWithTokenResult : Result
    {
        public TokenDto Data { get; set; }

        public string[]? Messages { get; }

        public CommandWithTokenResult(int statusCode, TokenDto data, params string[]? messages) : base(statusCode)
        {
            Messages = messages;
            Data = data;
        }
    }
}
