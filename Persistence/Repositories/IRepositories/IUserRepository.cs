using Dws.Note_one.Api.Domain.Models;

namespace Dws.Note_one.Api.Persistence.Repositories.IRepositories
{
     public interface IUserRepository
    {        Task<User> FirstOrDefaultAsync(String login, String password);        
    }
}