using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBestWayServerAPI.Application.Features.Commands.CategoryCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.CategoryCommand.Delete;
using TheBestWayServerAPI.Application.Features.Commands.CategoryCommand.Update;
using TheBestWayServerAPI.Application.Features.Queries.CategoryQueries.GetById;
using TheBestWayServerAPI.Application.Features.Queries.CategoryQueries.GetByIdWPosts;
using TheBestWayServerAPI.Application.Features.Queries.PostQueries.GetAllByCategoryId;

namespace TheBestWayServerAPI.WebAPI.Controllers
{
    [ApiController]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetByIdCategoryQueryRequest getByIdCategoryQueryRequest = new()
            {
                Id = id
            };
            var result = await _mediator.Send(getByIdCategoryQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}/posts")]
        public async Task<IActionResult> Get(int id, int page, int pageSize)
        {
            GetAllByCategoryIdPostQueryRequest getAllByCategoryIdPostQueryRequest = new()
            {
                CategoryId = id,
                Page= page,
                PageSize= pageSize
            };
            var result = await _mediator.Send(getAllByCategoryIdPostQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            var result = await _mediator.Send(createCategoryCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            var result = await _mediator.Send(updateCategoryCommandRequest);
            return StatusCode(result.StatusCode);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteCategoryCommandRequest deleteCategoryCommandRequest = new()
            {
                Id = id,
            };
            var result = await _mediator.Send(deleteCategoryCommandRequest);
            return StatusCode(result.StatusCode);
        }

        //OLD
        [HttpGet("GetWPosts/{id}")]
        public async Task<IActionResult> GetWPosts(int id, int page, int pageSize)
        {
            GetByIdCategoryWPostsQueryRequest getByIdCategoryWPostsQueryRequest = new()
            {
                Id = id,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(getByIdCategoryWPostsQueryRequest);
            return StatusCode(result.StatusCode, result);
        }
    }
}
