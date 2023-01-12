using Dws.Note_one.Api.Domain.Models;

namespace Dws.Note_one.Api.Persistence.Repositories.IRepositories
{
    public interface ICostumerRepository
    {
        Task<IEnumerable<Costumer>> ListAsync();
        Task<IEnumerable<Costumer>> ListByPositiveCreditAsync();
        Task<IEnumerable<Costumer>> ListByNegativeCreditAsync();
        Task AddAsync(Costumer costumer);
        Task<Costumer> FindByIdAsync(int id);
        Task<Costumer> FindByNameAsync(string name);
        void Update(Costumer costumer);
        void Remove(Costumer costumer);
    }
}