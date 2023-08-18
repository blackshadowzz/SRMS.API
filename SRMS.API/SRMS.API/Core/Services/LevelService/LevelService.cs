using Microsoft.EntityFrameworkCore;
using SRMS.API.Data.AppContext;
using SRMS.Shared.Models;
using System.Linq.Expressions;

namespace SRMS.API.Core.Services.LevelService
{
    public class LevelService : ILevelService
    {
        private readonly AppDbContext context;

        public LevelService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> CreateAsync(Level level)
        {
            try
            {
                context.Levels.Add(level);
                await SaveAsync();
                return true;

            }catch (Exception ex)
            {
                throw;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Level>> GetAllAsync(Expression<Func<Level, bool>>? condition = null)
        {
            IQueryable<Level> query = context.Levels;
            if(condition != null)
            {
                query = query.Where(condition);
            }
            return await query.AsNoTracking().ToListAsync()?? Enumerable.Empty<Level>();

        }

        public Task<Level> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public Task<bool> UpdateAsync(Level level)
        {
            throw new NotImplementedException();
        }
    }
}
