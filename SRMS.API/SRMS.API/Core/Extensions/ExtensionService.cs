using Microsoft.Extensions.DependencyInjection.Extensions;
using SRMS.API.Core.Services.Class1Service;
using SRMS.API.Core.Services.LevelService;
using SRMS.API.Core.Services.RegistrationService;

namespace SRMS.API.Core.Extensions
{
    public static class ExtensionService
    {
        /// Register Service here
        public static IServiceCollection AddClass(this IServiceCollection services)
        {
            services.TryAddScoped<IClassService, ClassService>();
            return services;
        }
        public static IServiceCollection AddLevel(this IServiceCollection services)
        {
            services.TryAddScoped<ILevelService, LevelService>();
            return services;
        }
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.TryAddScoped<IRegistrationService, RegistrationService>();
            return services;
        }
    }
}
