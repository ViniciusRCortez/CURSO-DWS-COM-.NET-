using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Services.Communication;

namespace Dws.Note_one.Api.Services.IServices
{
    public interface ICostumerService
    {
        Task<IEnumerable<Costumer>> ListAsync();
        Task<CostumerResponse> FindByIdAsync(int id);
        Task<CostumerResponse> FindByNameAsync(string name);
        Task<IEnumerable<Costumer>> ListByPositiveCreditAsync();
        Task<IEnumerable<Costumer>> ListByNegativeCreditAsync();
        Task<CostumerResponse> SaveAsync(Costumer costumer);
        Task<CostumerResponse> UpdateAsync(int id, Costumer costumer);
        Task<CostumerResponse> DeleteAsync(int id);


    }
}