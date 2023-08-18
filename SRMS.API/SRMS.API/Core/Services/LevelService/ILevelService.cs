using SRMS.Shared.Models;
using System.Linq.Expressions;

namespace SRMS.API.Core.Services.LevelService
{
    public interface ILevelService
    {
        Task<IEnumerable<Level>> GetAllAsync(Expression<Func<Level, bool>>? condition = null);
        Task<Level> GetByIdAsync(int id);
        Task<bool> CreateAsync(Level level);
        Task<bool> UpdateAsync(Level level);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
