using Application.Common;
using Application.TodoItems.Commands.Common;
using Application.TodoItems.Commands.DoneTodoItem;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using NUnit.Framework;

namespace Application.UnitTest.TodoItems.Commands
{
    public class DoneTodoItemTests : BaseTest
    {
        private ICommandHandler<DoneTodoItemCommand> _commandHandler;

        [SetUp]
        public void Setup() => _commandHandler = GetService<ICommandHandler<DoneTodoItemCommand>>();

        [Test]
        public async Task DoneDateShouldBeCorrectDateOfWhenTodoItemGetsDoneAsync()
        {
            //Arange
            var todoItem = new TodoItem(RandomTodoItemTitle);

            var todoContext = GetTodoContext();

            await todoContext.TodoItems.AddAsync(todoItem);
            await todoContext.SaveChangesAsync();


            //Act
            await _commandHandler.HandleAsync(new DoneTodoItemCommand(todoItem.Id));


            //Arange
            todoItem.DoneDate.Should().NotBeNull().And.Be(DateTime.UtcNow.Date);
        }

        [Test]
        public async Task ThrowExceptionWhenTodoItemNotFoundAsync()
        {
            var action = () => _commandHandler.HandleAsync(new DoneTodoItemCommand(0));

            await action.Should().ThrowAsync<TodoItemNotFoundException>();
        }
    }
}
