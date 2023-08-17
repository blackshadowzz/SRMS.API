using SRMS.Shared.Models;
using SRMS.Shared.Respones;
using System.Linq.Expressions;

namespace SRMS.API.Core.Services.Class1Service
{
    public interface IClassService
    {
        Task<IEnumerable<Class1>> GetAllAsync(Expression<Func<Class1, bool>>? condition = null);
        Task<Class1> GetByIdAsync(int id);
        Task<bool> CreateAsync(Class1 class1);
        Task<bool> UpdateAsync(Class1 class1);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
