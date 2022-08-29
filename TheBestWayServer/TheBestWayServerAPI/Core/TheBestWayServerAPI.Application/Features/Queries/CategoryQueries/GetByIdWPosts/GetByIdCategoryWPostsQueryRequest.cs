using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.IncludeModels;

namespace TheBestWayServerAPI.Application.Features.Queries.CategoryQueries.GetByIdWPosts
{
    public class GetByIdCategoryWPostsQueryRequest : IRequest<PaginatedQueryResult<CategoryWPostsViewModel>>
    {
        public int Id { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
