using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations
{
    public static class ServiceResolver
    {
        public static void ResolveInfrastructureServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<TodoContext>(options => options.UseSqlServer(connectionString));

            serviceCollection.AddScoped<ITodoContext>(provider => provider.GetRequiredService<TodoContext>());
        }
    }
}
