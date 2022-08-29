using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBestWayServerAPI.Application.Features.Commands.CommentCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.CommentCommand.Delete;
using TheBestWayServerAPI.Application.Features.Queries.CommentQueries.GetAllByPostId;
using TheBestWayServerAPI.Application.Features.Queries.CommentQueries.GetAllByUserId;

namespace TheBestWayServerAPI.WebAPI.Controllers
{
    [ApiController]
    public class CommentsController : BaseController
    {
        public CommentsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCommentCommandRequest createCommentCommandRequest)
        {
            var result = await _mediator.Send(createCommentCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteCommentCommandRequest deleteCommentCommandRequest = new DeleteCommentCommandRequest()
            {
                Id = id
            };
            var result = await _mediator.Send(deleteCommentCommandRequest);
            return StatusCode(result.StatusCode);
        }

        //OLD
        [HttpGet("GetForPost/{postId}")]
        public async Task<IActionResult> GetForPost(int postId, int page, int pageSize)
        {
            GetAllByPostIdCommentQueryRequest getAllByPostIdCommentQueryRequest = new()
            {
                PostId = postId,
                Page = page,
                PageSize = pageSize
            };

            var result = await _mediator.Send(getAllByPostIdCommentQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("GetForUser/{userId}")]
        public async Task<IActionResult> GetForUser(int userId, int page, int pageSize)
        {
            GetAllByUserIdCommentQueryRequest getAllByUserIdCommentQueryRequest = new()
            {
                UserId = userId,
                Page = page,
                PageSize = pageSize
            };

            var result = await _mediator.Send(getAllByUserIdCommentQueryRequest);
            return StatusCode(result.StatusCode, result);
        }
    }
}
