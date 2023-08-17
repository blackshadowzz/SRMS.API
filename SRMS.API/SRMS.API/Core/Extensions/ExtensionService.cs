using Microsoft.Extensions.DependencyInjection.Extensions;
using SRMS.API.Core.Services.Class1Service;

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
    }
}
