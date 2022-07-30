using Application.IntegrationTest.Common;
using Faker;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UnitTest.Common
{
    public abstract class BaseTest
    {
        protected TodoContext _todoContext;
        protected IServiceScopeFactory _serviceScopeFactory =
            new TodoApplicationFactory().Services.GetRequiredService<IServiceScopeFactory>();

        protected string RandomTodoItemTitle => Name.FullName(NameFormats.WithPrefix);
    }
}
