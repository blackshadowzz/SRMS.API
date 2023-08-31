using SRMS.Shared.Models;
using SRMS.Shared.Respones;

namespace SRMS.API.Core.Services.UserServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetOneUser(string username);
        Task<ResponeService<string?>> UserLogin(string username, string password);
        Task<bool> UpdateAsync(User user);
        Task<ResponeService<int?>> RegisterAsync(User user,string Password);
        Task<bool> DeleteAsync(int id);
        Task<bool> UserExist(string username);

    }
}
