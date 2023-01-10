using Dws.Note_one.Api.Domain.Models;

namespace Dws.Note_one.Api.Persistence.Repositories.IRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
        Task AddAsync(Product Product);
        Task<Product> FindByIdAsync(int id);
        Task<Product> FindByNameAsync(string name);
        void Update(Product Product);

        void Remove(Product Product);

    }
}