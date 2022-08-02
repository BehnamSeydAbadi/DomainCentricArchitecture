using Infrastructure;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IntegrationTest.Common
{
    internal sealed class TodoApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices((WebHostBuilderContext builder, IServiceCollection services) =>
            {
                Remove<DbContextOptions<TodoContext>>(services);

                services.AddDbContext<TodoContext>(
                    (serviceProvider, dbContextOptionsBuilder)
                        => dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "TodoDb"));
            });
        }

        private IServiceCollection Remove<TService>(IServiceCollection services)
        {
            var serviceDescriptor = services.FirstOrDefault(sd => sd.ServiceType == typeof(TService));

            if (serviceDescriptor != null)
                services.Remove(serviceDescriptor);

            return services;
        }
    }
}
