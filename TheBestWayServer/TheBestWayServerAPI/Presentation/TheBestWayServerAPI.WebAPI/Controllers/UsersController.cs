using MediatR;
using Microsoft.AspNetCore.Mvc;
using TheBestWayServerAPI.Application.Features.Commands.UserCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.UserCommand.Delete;
using TheBestWayServerAPI.Application.Features.Commands.UserCommand.Update;
using TheBestWayServerAPI.Application.Features.Queries.PostQueries.GetAll;
using TheBestWayServerAPI.Application.Features.Queries.UserQueries.GetById;

namespace TheBestWayServerAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetByIdUserQueryRequest getByIdUserQueryRequest = new()
            {
                Id = id
            };
            var result = await _mediator.Send(getByIdUserQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetPostsByUserId(int id, int page, int pageSize)
        {
            GetAllByUserIdPostQueryRequest getByIdPostQueryRequest = new()
            {
                UserId = id,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(getByIdPostQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetCommentsByUserId(int id, int page, int pageSize)
        {
            GetAllByUserIdPostQueryRequest getByIdPostQueryRequest = new()
            {
                UserId = id,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(getByIdPostQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}/questions")]
        public async Task<IActionResult> GetQuestionsByUserId(int id, int page, int pageSize)
        {
            GetAllByUserIdPostQueryRequest getByIdPostQueryRequest = new()
            {
                UserId = id,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(getByIdPostQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommandRequest createUserCommandRequest)
        {
            var result = await _mediator.Send(createUserCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateUserCommandRequest updateUserCommandRequest)
        {
            var result = await _mediator.Send(updateUserCommandRequest);
            return StatusCode(result.StatusCode);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteUserCommandRequest deleteUserCommandRequest = new()
            {
                Id = id
            };
            var result = await _mediator.Send(deleteUserCommandRequest);
            return StatusCode(result.StatusCode);
        }
    }
}
