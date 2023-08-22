using Microsoft.EntityFrameworkCore;
using SRMS.API.Data.AppContext;
using SRMS.Shared.Models;
using System.Linq.Expressions;

namespace SRMS.API.Core.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly AppDbContext context;

        public RegistrationService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> CreateAsync(Registration registration)
        {
            try
            {
                await context.Database.BeginTransactionAsync();
                context.Registrations.Add(registration);
                await SaveAsync();
                await context.Database.CommitTransactionAsync();
                return true;
            }catch (Exception ex)
            {
                await context.Database.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<bool> CreateLineAsync(RegistrationLine line)
        {
            context.RegistrationLines.Add(line);
            await SaveAsync();
            return true;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Registration>> GetAllAsync(Expression<Func<Registration, bool>>? condition = null)
        {
            IQueryable<Registration> registrations= context.Registrations.Include(x=>x.RegistrationLines);
            if (condition != null)
            {
                registrations = registrations.Where(condition).Include(x => x.RegistrationLines);
            }
            return await registrations.AsNoTracking().ToListAsync()?? Enumerable.Empty<Registration>();
        }

        public async Task<Registration?> GetByIdAsync(int id)
        {
            return await context.Registrations
                .Include(x => x.RegistrationLines)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.RegistrationId == id);
        }

        public async Task<RegistrationLine?> GetLineByIdAsync(int id)
        {
            return await context.RegistrationLines
                .AsNoTracking().FirstOrDefaultAsync(x=>x.RegistrationLineId == id);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public Task<bool> UpdateAsync(Registration registration)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateLineAsync(RegistrationLine registrationLine)
        {
            try
            {
                context.Entry(registrationLine).State=EntityState.Modified;
                await SaveAsync();
                return true;
            }catch (Exception ex)
            {
                throw;
            }
        }
    }
}
