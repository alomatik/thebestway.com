using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.QuestionAnswerModels;

namespace TheBestWayServerAPI.Application.Features.Queries.QuestionAnswerQueries.GetAllByQuestionId
{
    public class GetAllByQuestionIdQuestionAnswerRequest:IRequest<PaginatedQueryResult<List<QuestionAnswerViewModel>>>
    {
        public int QuestionId { get; set; }

        public int Page { get; set; }
        
        public int PageSize { get; set; }
    }
}
