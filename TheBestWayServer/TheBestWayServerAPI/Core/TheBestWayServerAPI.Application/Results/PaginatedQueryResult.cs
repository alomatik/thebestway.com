using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.ViewModels;

namespace TheBestWayServerAPI.Application.Results
{
    public class PaginatedQueryResult<T> : QueryResult<T>
    {
        public Pagination Pagination { get; }

        public PaginatedQueryResult(int statusCode, T data, Pagination pagination) : base(statusCode, data)
        {
            Pagination = pagination;
        }

    }
}
