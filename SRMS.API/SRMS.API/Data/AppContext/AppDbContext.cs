using Microsoft.EntityFrameworkCore;
using SRMS.Shared.Models;

namespace SRMS.API.Data.AppContext
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        
        public DbSet<Class1> Class1s { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectType> SubjectTypes { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<RegistrationLine> RegistrationLines { get; set; }
    }
}
