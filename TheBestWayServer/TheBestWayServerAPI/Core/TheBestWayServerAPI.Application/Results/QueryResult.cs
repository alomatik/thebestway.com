using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.Results
{
    public class QueryResult<T> : Result
    {
        public T Data { get; }

        public QueryResult(int statusCode, T data) : base(statusCode)
        {
            Data = data;
        }

    }
}
