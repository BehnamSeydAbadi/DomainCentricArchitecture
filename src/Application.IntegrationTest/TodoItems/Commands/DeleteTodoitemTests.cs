using Application.Common;
using Application.TodoItems.Commands.Common;
using Application.TodoItems.Commands.DeleteTodoItem;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.UnitTest.TodoItems.Commands
{
    public class DeleteTodoItemTests : BaseTest
    {
        private ICommandHandler<DeleteTodoItemCommand> _commandHandler;

        [SetUp]
        public void Setup() => _commandHandler = GetService<ICommandHandler<DeleteTodoItemCommand>>();

        [Test]
        public async Task DeleteTodoItemSuccessfullyAsync()
        {
            //Arange
            var todoItem = new TodoItem(RandomTodoItemTitle);

            var todoContext = GetTodoContext();

            await todoContext.TodoItems.AddAsync(todoItem);
            await todoContext.SaveChangesAsync();


            //Act
            await _commandHandler.HandleAsync(new DeleteTodoItemCommand(todoItem.Id));


            //Assert
            var todoItems = await todoContext.TodoItems.ToListAsync();
            todoItems.Should().BeEmpty();
        }

        [Test]
        public async Task ThrowExceptionWhenTodoItemNotFoundAsync()
        {
            var action = () => _commandHandler.HandleAsync(new DeleteTodoItemCommand(0));

            await action.Should().ThrowAsync<TodoItemNotFoundException>();
        }

    }
}
