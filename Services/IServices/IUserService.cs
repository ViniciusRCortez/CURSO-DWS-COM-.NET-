using Dws.Note_one.Api.Domain.Models;

namespace Dws.Note_one.Api.Services.IServices
{
    public interface IUserService
    {
        Task<User> FirstOrDefaultAsync(String login, String password);
    }
}