using Application.Common;
using Application.TodoItems.Commands.CreateTodoItem;
using Application.UnitTest.Common;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.UnitTest.TodoItems.Commands
{
    public class CreateTodoItemTests : BaseTest
    {
        private ICommandHandler<CreateTodoItemCommand> _commandHandler;

        [SetUp]
        public void Setup() => _commandHandler = GetService<ICommandHandler<CreateTodoItemCommand>>();

        [Test]
        public async Task CreateTodoItemSuccessfullyAsync()
        {
            //Arange
            var todoItemTitle = RandomTodoItemTitle;

            //Act
            await _commandHandler.HandleAsync(new CreateTodoItemCommand(todoItemTitle));

            //Assert
            var todoItem = await TodoContext.TodoItems.SingleOrDefaultAsync();
            todoItem.Title.Should().Be(todoItemTitle);
        }
    }
}
