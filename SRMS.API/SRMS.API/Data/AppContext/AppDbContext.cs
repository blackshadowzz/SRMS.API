using Microsoft.EntityFrameworkCore;
using SRMS.Shared.Models;

namespace SRMS.API.Data.AppContext
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        
        public DbSet<Class1> Class1s { get; set; }
    }
}
