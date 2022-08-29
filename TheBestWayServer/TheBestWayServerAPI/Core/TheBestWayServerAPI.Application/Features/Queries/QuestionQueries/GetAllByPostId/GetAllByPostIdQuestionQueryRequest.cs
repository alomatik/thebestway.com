using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.QuestionModels;

namespace TheBestWayServerAPI.Application.Features.Queries.QuestionQueries.GetAllByPostId
{
    public class GetAllByPostIdQuestionQueryRequest: IRequest<PaginatedQueryResult<List<QuestionViewModel>>>
    {
        public int PostId { get; set; }
        
        public int Page { get; set; }
        
        public int PageSize { get; set; }
    }
}
