using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBestWayServerAPI.Application.Features.Commands.RoleCommand.Create;

namespace TheBestWayServerAPI.WebAPI.Controllers
{
    [ApiController]
    public class RolesController : BaseController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateRoleCommandRequest createRoleCommandRequest)
        { 
            var result = await _mediator.Send(createRoleCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

    }
}
