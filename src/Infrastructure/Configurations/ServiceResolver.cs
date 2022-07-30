using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations
{
    public static class ServiceResolver
    {
        public static void ResolveInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITodoContext, TodoContext>();
        }
    }
}
