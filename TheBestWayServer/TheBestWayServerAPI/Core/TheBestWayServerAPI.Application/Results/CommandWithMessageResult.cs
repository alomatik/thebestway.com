using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.Results
{
    public class CommandWithMessageResult : Result
    {
        public string[] Messages { get; }

        public CommandWithMessageResult(int statusCode, params string[] messages) : base(statusCode)
        {
            Messages = messages;
        }
    }
}
