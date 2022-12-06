using Application.TodoItems.Commands.SetDueDateTodoItem;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using NUnit.Framework;
using MediatR;

namespace Application.IntegrationTest.TodoItems.Commands
{
    public class SetDueDateTodoItemTests : BaseTest
    {
        private ISender _mediator;

        [SetUp]
        public void Setup() => _mediator = GetService<ISender>();

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
            await _mediator.Send(new SetDueDateTodoItemCommand(todoItem.Id, dueDate));


            //Arange
            todoItem.DueDate.Should().NotBeNull().And.Be(dueDate);
        }
    }
}
