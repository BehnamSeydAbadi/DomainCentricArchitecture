using Application.Common;
using Application.TodoItems.Commands.CreateTodoItem;
using Application.TodoItems.Commands.DeleteTodoItem;
using Application.TodoItems.Commands.DoneTodoItem;
using Application.TodoItems.Commands.UndoneTodoItem;
using Application.TodoItems.Queries.GetTodayTodoItems;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations
{
    public static class ServiceResolver
    {
        public static void ResolveApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICommandHandler<CreateTodoItemCommand>, CreateTodoItemCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<DeleteTodoItemCommand>, DeleteTodoItemCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<DoneTodoItemCommand>, DoneTodoItemCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<UndoneTodoItemCommand>, UndoneTodoItemCommandHandler>();

            serviceCollection.AddScoped<IQueryHandler<TodoItemViewModel>, GetTodayTodoItemsQueryHandler>();
        }
    }
}
