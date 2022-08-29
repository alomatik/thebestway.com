using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBestWayServerAPI.Application.Features.Commands.QuestionCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.QuestionCommand.Delete;
using TheBestWayServerAPI.Application.Features.Queries.QuestionAnswerQueries.GetAllByQuestionId;
using TheBestWayServerAPI.Application.Features.Queries.QuestionQueries.GetAllByPostId;
using TheBestWayServerAPI.Application.Features.Queries.QuestionQueries.GetAllByUserId;

namespace TheBestWayServerAPI.WebAPI.Controllers
{
    [ApiController]
    public class QuestionsController : BaseController
    {
        public QuestionsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet("{id}/questionAnswers")]
        public async Task<IActionResult> Get(int id, int page, int pageSize)
        {
            GetAllByQuestionIdQuestionAnswerRequest getAllByQuestionIdQuestionAnswerRequest = new()
            {
                QuestionId = id,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(getAllByQuestionIdQuestionAnswerRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateQuestionCommandRequest createQuestionCommandRequest)
        {
            var result = await _mediator.Send(createQuestionCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteQuestionCommandRequest deleteQuestionCommandRequest = new DeleteQuestionCommandRequest()
            {
                Id = id
            };
            var result = await _mediator.Send(deleteQuestionCommandRequest);
            return StatusCode(result.StatusCode);
        }


        //OLD
        [HttpGet("GetForPost/{postId}")]
        public async Task<IActionResult> GetForPost(int postId, int page, int pageSize)
        {
            GetAllByPostIdQuestionQueryRequest getAllByPostIdQuestionQueryRequest = new()
            {
                PostId = postId,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(getAllByPostIdQuestionQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("GetForUser/{userId}")]
        public async Task<IActionResult> GetForUser(int userId, int page, int pageSize)
        {
            GetAllByUserIdQuestionQueryRequest getAllByUserIdQuestionQueryRequest = new()
            {
                UserId = userId,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(getAllByUserIdQuestionQueryRequest);
            return StatusCode(result.StatusCode, result);
        }
    }
}
