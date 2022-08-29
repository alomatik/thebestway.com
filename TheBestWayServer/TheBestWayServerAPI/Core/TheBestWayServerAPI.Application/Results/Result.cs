using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.Results
{
    public abstract class Result
    {
        public int StatusCode { get; }

        public Result(int statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
