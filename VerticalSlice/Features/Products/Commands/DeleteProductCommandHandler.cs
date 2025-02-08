using FluentResults;
using MediatR;

namespace VerticalSlice.Features.Products.Commands
{

    public record DeleteProductCommand(Guid Id) : IRequest<Result>;

    public class DeleteProductCommandHandler(ProductRepository repository) : IRequestHandler<DeleteProductCommand, Result>
    {
        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (product is null)
                return Result.Fail("Product not found");

            await repository.DeleteAsync(product, cancellationToken);
            return Result.Ok();
        }
    }
}
