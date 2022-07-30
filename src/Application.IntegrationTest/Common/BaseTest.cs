using Application.IntegrationTest.Common;
using Application.Interfaces;
using Faker;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UnitTest.Common
{
    public abstract class BaseTest
    {
        protected ITodoContext GetTodoContext() => GetService<ITodoContext>();
        protected string RandomTodoItemTitle => Name.FullName(NameFormats.WithPrefix);


        protected IService GetService<IService>()
        {
            var serviceProvider = new TodoApplicationFactory().Services
                   .GetRequiredService<IServiceScopeFactory>()
                   .CreateScope()
                   .ServiceProvider;

            return (IService)serviceProvider.GetService(typeof(IService));
        }
    }
}
