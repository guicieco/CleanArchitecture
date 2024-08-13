#region Using

using Ardalis.Result;
using CleanArchitecture.Management.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitecture.Management.Application.Features.Categories.Commands.DeleteCategory;
using CleanArchitecture.Management.Application.Features.Categories.Commands.UpdateCategory;
using CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoriesList;
using CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoryDetail;
using CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoryPaged;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace CleanArchitecture.Management.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAll()
        {
            var categories = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDetailVm>> GetById(Guid id)
        {
            var getCategoryDetailQuery = new GetCategoryDetailQuery() { Id = id };
            var result = await _mediator.Send(getCategoryDetailQuery);

            if (result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(result);
        }

        [HttpGet("/paged", Name = "GetPagedCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CategoryPagedVm>> GetPagedOrdersForMonth(string? name, int page, int size)
        {
            var getCategoryPagedQuery = new GetCategoryPagedQuery() { Name = name, Page = page, Size = size };
            var dtos = await _mediator.Send(getCategoryPagedQuery);

            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<Result<CreateCategoryVm>>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var result = await _mediator.Send(createCategoryCommand);

            if (result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(result);
        }

        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            var result = await _mediator.Send(updateCategoryCommand);
            
            if (result.IsSuccess)
                return Ok();

            return BadRequest(result);
        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCategoryCommand = new DeleteCategoryCommand() { Id = id };
            var result = await _mediator.Send(deleteCategoryCommand);

            if (result.IsSuccess)
                return Ok();

            return BadRequest(result);
        }
    }
}
