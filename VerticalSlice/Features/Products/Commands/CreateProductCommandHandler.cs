using FluentResults;
using MediatR;
using VerticalSlice.Domain;

namespace VerticalSlice.Features.Products.Commands
{

    public record CreateProductCommand(string Name, decimal Price) : IRequest<Result<Guid>>;

    public class CreateProductCommandHandler(ProductRepository repository)
        : IRequestHandler<CreateProductCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Price);
            await repository.AddAsync(product, cancellationToken);

            return Result.Ok(product.Id);
        }
    }
}
