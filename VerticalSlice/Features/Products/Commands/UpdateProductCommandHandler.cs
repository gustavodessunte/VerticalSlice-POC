using FluentResults;
using MediatR;

namespace VerticalSlice.Features.Products.Commands
{
    public record UpdateProductCommand(Guid Id, string Name, decimal Price) : IRequest<Result>;
    public class UpdateProductCommandHandler(ProductRepository repository) : IRequestHandler<UpdateProductCommand, Result>
    {
        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (product is null)
                return Result.Fail("Product not found");

            product.Update(request.Name, request.Price);
            await repository.UpdateAsync(product, cancellationToken);

            return Result.Ok();
        }
    }
}
