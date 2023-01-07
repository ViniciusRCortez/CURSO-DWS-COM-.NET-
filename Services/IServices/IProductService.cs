using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Services.Communication;

namespace Dws.Note_one.Api.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
        Task<ProductResponse> SaveAsync(Product product);

        Task<ProductResponse> UpdateAsync(int id, Product product);

        Task<ProductResponse> DeleteAsync(int id);


    }
}