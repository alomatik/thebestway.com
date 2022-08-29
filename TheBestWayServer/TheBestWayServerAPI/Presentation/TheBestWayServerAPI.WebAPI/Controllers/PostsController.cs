using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBestWayServerAPI.Application.Features.Commands.PostCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.PostCommand.Delete;
using TheBestWayServerAPI.Application.Features.Commands.PostCommand.Update;
using TheBestWayServerAPI.Application.Features.Queries.CommentQueries.GetAllByPostId;
using TheBestWayServerAPI.Application.Features.Queries.PostQueries.GetAll;
using TheBestWayServerAPI.Application.Features.Queries.PostQueries.GetById;
using TheBestWayServerAPI.Application.Features.Queries.QuestionQueries.GetAllByPostId;

namespace TheBestWayServerAPI.WebAPI.Controllers
{
    [ApiController]
    public class PostsController : BaseController
    {
        public PostsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetByIdPostQueryRequest getByIdPostQueryRequest = new()
            {
                Id = id
            };
            var result = await _mediator.Send(getByIdPostQueryRequest);
            return StatusCode(result.StatusCode,result);
        }

        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetCommentsByPostId(int id, int page, int pageSize)
        {
            GetAllByPostIdCommentQueryRequest getAllByPostIdCommentQueryRequest = new()
            {
                PostId = id,
                Page= page,
                PageSize= pageSize
            };
            var result = await _mediator.Send(getAllByPostIdCommentQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}/questions")]
        public async Task<IActionResult> GetQuestionsByPostId(int id, int page, int pageSize)
        {
            GetAllByPostIdQuestionQueryRequest getAllByPostIdQuestionQueryRequest = new()
            {
                PostId= id,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(getAllByPostIdQuestionQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePostCommandRequest createPostCommandRequest)
        {
            var result = await _mediator.Send(createPostCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePostCommandRequest updatePostCommandRequest)
        {
            var result = await _mediator.Send(updatePostCommandRequest);
            return StatusCode(result.StatusCode);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletePostCommandRequest deletePostCommandRequest = new DeletePostCommandRequest()
            {
                Id = id
            };
            var result = await _mediator.Send(deletePostCommandRequest);
            return StatusCode(result.StatusCode);
        }

        //OLD
        //GetForCategoryId
    }
}
