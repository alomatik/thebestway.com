using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.QuestionModels;

namespace TheBestWayServerAPI.Application.Features.Queries.QuestionQueries.GetAllByUserId
{
    public class GetAllByUserIdQuestionQueryRequest: IRequest<PaginatedQueryResult<List<QuestionForUserViewModel>>>
    {
        public int UserId { get; set; }
        
        public int Page { get; set; }
        
        public int PageSize { get; set; }

    }
}
