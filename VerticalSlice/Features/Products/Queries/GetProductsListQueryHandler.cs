using FluentResults;
using MediatR;
using VerticalSlice.Domain;

namespace VerticalSlice.Features.Products.Queries
{

    public record GetProductsListQuery : IRequest<Result<List<Product>>>;

    public class GetProductsListQueryHandler(ProductRepository repository) : IRequestHandler<GetProductsListQuery, Result<List<Product>>>
    {
        public async Task<Result<List<Product?>>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var products = await repository.GetAllAsync(cancellationToken);
            return Result.Ok(products);
        }
    }
}
