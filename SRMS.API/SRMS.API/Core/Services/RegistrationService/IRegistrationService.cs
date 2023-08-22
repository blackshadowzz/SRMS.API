using SRMS.Shared.Models;
using System.Linq.Expressions;

namespace SRMS.API.Core.Services.RegistrationService
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Registration>> GetAllAsync(Expression<Func<Registration, bool>>? condition = null);
        Task<Registration?> GetByIdAsync(int id);
        Task<RegistrationLine?> GetLineByIdAsync(int id);
        Task<bool> CreateAsync(Registration registration);
        Task<bool> CreateLineAsync(RegistrationLine line);
        Task<bool> UpdateAsync(Registration registration);
        Task<bool> UpdateLineAsync(RegistrationLine registrationLine);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
