using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.CommentModels;

namespace TheBestWayServerAPI.Application.Features.Queries.CommentQueries.GetAllByUserId
{
    public class GetAllByUserIdCommentQueryRequest : IRequest<PaginatedQueryResult<List<CommentForUserViewModel>>>
    {
        public int UserId { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 5;

    }
}
