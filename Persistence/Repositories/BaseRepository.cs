using Dws.Note_one.Api.Persistence.Context;

namespace Dws.Note_one.Api.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MySQLContext _context;

        public BaseRepository(MySQLContext context)
        {
            _context = context;
        }
    }
}