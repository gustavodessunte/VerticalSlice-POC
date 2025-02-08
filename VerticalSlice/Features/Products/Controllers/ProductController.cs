using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSlice.Features.Products.Commands;
using VerticalSlice.Features.Products.Queries;

namespace VerticalSlice.Features.Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest(result.Errors);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
        {

            if (id != command.Id)
                return BadRequest("Id mismatch");

            var result = await mediator.Send(command);

            return result.IsSuccess ? NoContent() : BadRequest(result.Errors);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await mediator.Send(new DeleteProductCommand(id));
            return result.IsSuccess ? NoContent() : NotFound(result.Errors);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await mediator.Send(new GetProductsByIdQuery(id));
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await mediator.Send(new GetProductsListQuery());
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Errors);
        }

    }
}
