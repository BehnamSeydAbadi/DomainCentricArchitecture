using Application.Common;
using Application.TodoItems.Commands.SetDueDateTodoItem;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using NUnit.Framework;

namespace Application.IntegrationTest.TodoItems.Commands
{
    public class SetDueDateTodoItemTests : BaseTest
    {
        private ICommandHandler<SetDueDateTodoItemCommand> _commandHandler;

        [SetUp]
        public void Setup() => _commandHandler = GetService<ICommandHandler<SetDueDateTodoItemCommand>>();

        [Test]
        public async Task DueDateShouldBeCorrectDateOfWhenTodoItemDueDateIsSetAsync()
        {
            //Arange
            var todoItem = new TodoItem(RandomTodoItemTitle);

            var todoContext = GetTodoContext();

            await todoContext.TodoItems.AddAsync(todoItem);
            await todoContext.SaveChangesAsync();

            var dueDate = DateTime.UtcNow.Date;

            //Act
            await _commandHandler.HandleAsync(new SetDueDateTodoItemCommand(todoItem.Id, dueDate));


            //Arange
            todoItem.DueDate.Should().NotBeNull().And.Be(dueDate);
        }
    }
}
