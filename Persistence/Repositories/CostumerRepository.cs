using Microsoft.EntityFrameworkCore;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Persistence.Repositories.IRepositories;
using Dws.Note_one.Api.Persistence.Context;

namespace Dws.Note_one.Api.Persistence.Repositories
{
    public class CostumerRepository : BaseRepository, ICostumerRepository
    {
        public CostumerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Costumer>> ListAsync()
        {
            return await _context.Costumers.ToListAsync();
        }

        public async Task<IEnumerable<Costumer>> ListByPositiveCreditAsync()
        {
            return await _context.Costumers
                    .Where(x => x.Credit >= 0)
                    .ToListAsync();
        }
        public async Task<IEnumerable<Costumer>> ListByNegativeCreditAsync()
        {
            return await _context.Costumers
                    .Where(x => x.Credit < 0)
                    .ToListAsync();
        }

        public async Task AddAsync(Costumer costumer)
        {
            await _context.Costumers.AddAsync(costumer);
        }

        public async Task<Costumer> FindByIdAsync(int id)
        {
            return await _context.Costumers.FindAsync(id);
        }

        public async Task<Costumer> FindByNameAsync(string name)
        {
            return await _context.Costumers
                    .FirstOrDefaultAsync(x => x.Name == name);
        }

        public void Update(Costumer costumer)
        {
            _context.Costumers.Update(costumer);
        }

        public void Remove(Costumer costumer)
        {
            _context.Costumers.Remove(costumer);
        }

    }
}