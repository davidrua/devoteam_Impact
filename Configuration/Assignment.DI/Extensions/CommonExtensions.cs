namespace Assignment.DI.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public static class CommonExtensions
    {
        public static IServiceCollection AddCommonDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(Assembly.GetEntryAssembly());
            return services;
        }
    }
}