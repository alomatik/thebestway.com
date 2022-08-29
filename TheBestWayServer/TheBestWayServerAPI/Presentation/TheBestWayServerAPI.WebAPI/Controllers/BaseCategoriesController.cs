using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBestWayServerAPI.Application.Features.Commands.BaseCategoryCommand.Create;
using TheBestWayServerAPI.Application.Features.Queries.BaseCategoryQueries.GetAll;
using TheBestWayServerAPI.Application.Features.Queries.BaseCategoryQueries.GetById;
using TheBestWayServerAPI.Application.Features.Queries.BaseCategoryQueries.GetByIdWCategories;
using TheBestWayServerAPI.Application.Features.Queries.CategoryQueries.GetAllByBaseCategoryId;

namespace TheBestWayServerAPI.WebAPI.Controllers
{
    [ApiController]
    public class BaseCategoriesController : BaseController
    {

        private readonly ILogger<BaseCategoriesController> _logger;

        public BaseCategoriesController(IMediator mediator, ILogger<BaseCategoriesController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetByIdBaseCategoryQueryRequest getByIdBaseCategoryQueryRequest = new()
            {
                Id = id
            };
            var result = await _mediator.Send(getByIdBaseCategoryQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int pageSize)
        {
            GetAllBaseCategoryQueryRequest getAllBaseCategoryQueryRequest = new()
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(getAllBaseCategoryQueryRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}/categories")]
        public async Task<IActionResult> GetCategoriesByBaseCategoryId(int id, int page, int pageSize)
        {
            GetAllByBaseCategoryIdCategoryRequest getAllByBaseCategoryIdCategoryRequest = new()
            {
                BaseCategoryId = id,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(getAllByBaseCategoryIdCategoryRequest);
            return StatusCode(result.StatusCode, result);
        }

        //OLD
        [HttpGet("GetWCategories/{id}")]
        public async Task<IActionResult> GetWCategories(int id, int page, int pageSize)
        {
            GetByIdBaseCategoryWCategoriesQueryRequest getByIdBaseCategoryWCategoriesQueryRequest = new()
            {
                Id = id,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(getByIdBaseCategoryWCategoriesQueryRequest);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateBaseCategoryCommandRequest createBaseCategoryCommandRequest)
        {
            var result = await _mediator.Send(createBaseCategoryCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

    }
}
