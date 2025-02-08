using Microsoft.EntityFrameworkCore;
using VerticalSlice.Domain;
using VerticalSlice.Infrastructure.Context;

namespace VerticalSlice.Features.Products
{
    public class ProductRepository(ProductDbContext context)
    {
        public async Task<List<Product?>> GetAllAsync(CancellationToken cancellationToken) => await context.Products.ToListAsync(cancellationToken);

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Products
                .Where(p => p != null && p.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken)
        {
            await context.Products.AddAsync(product, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Product product, CancellationToken cancellationToken)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken) => 
            await context.Products.AnyAsync(p => p != null && p.Id == id, cancellationToken);

        public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken) => 
            await context.Products.AnyAsync(p => p != null && p.Name == name, cancellationToken);

        public async Task<bool> ExistsAsync(Guid id, string name, CancellationToken cancellationToken) => 
            await context.Products.AnyAsync(p => p != null && p.Id != id && p.Name == name, cancellationToken);

        public async Task<bool> ExistsAsync(Guid id, string name, decimal price, CancellationToken cancellationToken) => 
            await context.Products
                .AnyAsync(p =>
                    p != null 
                    && p.Id != id 
                    && p.Name == name 
                    && p.Price == price,
                    cancellationToken
                    );
    }
}
