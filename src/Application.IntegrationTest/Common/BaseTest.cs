using Application.IntegrationTest.Common;
using Application.Interfaces;
using Faker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UnitTest.Common
{
    public abstract class BaseTest
    {
        private readonly IServiceScope _serviceScope;

        public BaseTest()
        {
            _serviceScope = new TodoApplicationFactory().Services
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
        }

        protected ITodoContext GetTodoContext() => GetService<ITodoContext>();
        protected string RandomTodoItemTitle => Name.FullName(NameFormats.WithPrefix);


        protected IService GetService<IService>()
        {
            var serviceProvider = _serviceScope.ServiceProvider;

            return (IService)serviceProvider.GetRequiredService(typeof(IService));
        }
    }
}
