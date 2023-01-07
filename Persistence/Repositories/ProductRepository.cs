using Microsoft.EntityFrameworkCore;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Persistence.Repositories.IRepositories;
using Dws.Note_one.Api.Persistence.Context;

namespace Dws.Note_one.Api.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(MySQLContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                    .Where(x => x.CategoryId == categoryId)
                    .ToListAsync();
        }

        public async Task AddAsync(Product Product)
        {
            await _context.Products.AddAsync(Product);
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public void Update(Product Product)
        {
            _context.Products.Update(Product);
        }

        public void Remove(Product Product)
        {
            _context.Products.Remove(Product);
        }

    }
}