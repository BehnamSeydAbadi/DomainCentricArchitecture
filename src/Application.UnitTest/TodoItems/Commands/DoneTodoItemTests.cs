using Application.TodoItems.Commands;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using NUnit.Framework;

namespace Application.UnitTest.TodoItems.Commands
{
    public class DoneTodoItemTests : BaseTest
    {
        private DoneTodoItemCommandHandler _commandHandler;

        [SetUp]
        public void Setup() => _commandHandler = new DoneTodoItemCommandHandler(_todoContext);

        [Test]
        public async Task DoneDateShouldBeCorrectDateOfWhenTodoItemGetsDoneAsync()
        {
            //Arange
            var todoItem = new TodoItem(RandomTodoItemTitle);

            await _todoContext.TodoItems.AddAsync(todoItem);
            await _todoContext.SaveChangesAsync();


            //Act
            await _commandHandler.HandleAsync(new DoneTodoItemCommand(todoItem.Id));


            //Arange
            todoItem.DoneDate.Should().NotBeNull().And.Be(DateTime.Now.Date);
        }

        [Test]
        public async Task ThrowExceptionWhenTodoItemNotFoundAsync()
        {
            var action = () => _commandHandler.HandleAsync(new DoneTodoItemCommand(0));

            await action.Should().ThrowAsync<TodoItemNotFoundException>();
        }
    }
}
