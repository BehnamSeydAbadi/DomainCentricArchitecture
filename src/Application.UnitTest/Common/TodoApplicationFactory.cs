using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Application.IntegrationTest.Common
{
    internal sealed class TodoApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var todoContextOptionsBuilder = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "TodoDb")
                .Options;

            builder.ConfigureServices((WebHostBuilderContext builder, IServiceCollection services) =>
            {
                services.AddDbContext<TodoContext>(
                    (serviceProvider, dbContextOptionsBuilder)
                        => dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "TodoDb"));
            });
        }
    }
}
