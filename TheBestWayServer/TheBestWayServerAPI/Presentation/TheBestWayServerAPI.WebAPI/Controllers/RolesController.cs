using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBestWayServerAPI.Application.Features.Commands.RoleCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.RoleCommand.Delete;
using TheBestWayServerAPI.Application.Features.Commands.RoleCommand.Update;
using TheBestWayServerAPI.Application.Features.Queries.RoleQueries.GetAll;

namespace TheBestWayServerAPI.WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class RolesController : BaseController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllRoleQueryRequest getAllRoleQueryRequest = new();
            var result = await _mediator.Send(getAllRoleQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateRoleCommandRequest createRoleCommandRequest)
        {
            var result = await _mediator.Send(createRoleCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            var result = await _mediator.Send(updateRoleCommandRequest);
            return StatusCode(result.StatusCode);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteRoleCommandRequest deleteRoleCommandRequest = new()
            {
                Id = id
            };

            var result = await _mediator.Send(deleteRoleCommandRequest);
            return StatusCode(result.StatusCode);
        }


    }
}
