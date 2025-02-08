using FluentResults;
using MediatR;
using VerticalSlice.Domain;

namespace VerticalSlice.Features.Products.Queries
{

    public record GetProductsByIdQuery(Guid Id) : IRequest<Result<Product>>;

    public class GetProductsByIdQueryHandler(ProductRepository repository) : IRequestHandler<GetProductsByIdQuery, Result<Product>> 
    {
        public async Task<Result<Product>> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(request.Id, cancellationToken);
            return product is null ? Result.Fail("Product not found") : Result.Ok(product);
        }
    }
}
