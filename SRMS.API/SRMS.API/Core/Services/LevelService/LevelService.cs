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

        public async Task<bool> DeleteAsync(int id)
        {
            var result= await context.Levels.AsNoTracking().FirstOrDefaultAsync(x=>x.LevelId==id);
            context.Levels.Remove(result);
            await SaveAsync();
            return true;

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

        public async Task<Level?> GetByIdAsync(int id)
        {
            return await context.Levels.AsNoTracking().FirstOrDefaultAsync(x => x.LevelId == id);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Level level)
        {
            context.Levels.Update(level);
            await SaveAsync();
            return true;
        }
    }
}
