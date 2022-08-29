using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.Results
{
    public class CommandNoMessageResult : Result
    {
        public CommandNoMessageResult(int statusCode) : base(statusCode)
        {

        }
    }
}
