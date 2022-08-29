using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBestWayServerAPI.Application.Features.Commands.QuestionAnswerCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.QuestionAnswerCommand.Delete;
using TheBestWayServerAPI.Application.Features.Queries.QuestionAnswerQueries.GetAllByQuestionId;

namespace TheBestWayServerAPI.WebAPI.Controllers
{
    [ApiController]
    public class QuestionAnswersController : BaseController
    {
        public QuestionAnswersController(IMediator mediator) : base(mediator)
        {

        }


      
        [HttpPost]
        public async Task<IActionResult> Post(CreateQuestionAnswerCommandRequest createQuestionAnswerCommandRequest)
        {
            var result = await _mediator.Send(createQuestionAnswerCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteQuestionAnswerCommandRequest deleteQuestionAnswerCommandRequest = new DeleteQuestionAnswerCommandRequest()
            {
                Id = id
            };
            var result = await _mediator.Send(deleteQuestionAnswerCommandRequest);
            return StatusCode(result.StatusCode);
        }
        
        //OLD
        [HttpGet("GetForQuestion/{questionId}")]
        public async Task<IActionResult> GetForQuestion(int questionId, int page, int pageSize)
        {
            GetAllByQuestionIdQuestionAnswerRequest getAllByQuestionIdQuestionAnswerRequest = new()
            {
                QuestionId = questionId,
                Page = page,
                PageSize = pageSize
            };

            var result = await _mediator.Send(getAllByQuestionIdQuestionAnswerRequest);
            return StatusCode(result.StatusCode, result);
        }

    }
}
