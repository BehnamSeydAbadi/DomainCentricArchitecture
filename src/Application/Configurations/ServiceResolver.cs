using Application.Common;
using Application.TodoItems.Queries.GetTodayTodoItems;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Configurations
{
    public static class ServiceResolver
    {
        public static void ResolveApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

            serviceCollection.AddScoped<IQueryHandler<TodoItemViewModel>, GetTodayTodoItemsQueryHandler>();
        }
    }
}
