using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SRMS.API.Data.AppContext;
using SRMS.Shared.Models;
using SRMS.Shared.Respones;
using System.Linq.Expressions;

namespace SRMS.API.Core.Services.Class1Service
{
    public class ClassService : IClassService
    {
        private readonly AppDbContext context;

        public ClassService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> CreateAsync(Class1 class1)
        {
            try
            {
                context.Class1s.Add(class1);
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

        public async Task<IEnumerable<Class1>> GetAllAsync(Expression<Func<Class1, bool>>? condition = null)
        {
            IQueryable<Class1> results = context.Class1s;
            if (condition != null)
            {
                results = results.Where(condition);
            }

            return await results.AsNoTracking().ToListAsync() ?? Enumerable.Empty<Class1>();
        }

        public Task<Class1> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public Task<bool> UpdateAsync(Class1 class1)
        {
            throw new NotImplementedException();
        }
    }
}
