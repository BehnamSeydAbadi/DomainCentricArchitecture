using Domain.TodoItems;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.UnitTest.TodoItems
{
    public class TodoItemTests
    {
        [Test]
        public void WhenTodoItemGetsDoneDateShouldBeUpdated()
        {
            var todoItem = new TodoItem();

            todoItem.MakeItDone();

            todoItem.DoneDate.Should().Be(DateTime.UtcNow.Date);
        }

        [Test]
        public void WhenTodoItemGetsUndoneDateShouldBe()
        {
            var todoItem = new TodoItem();

            todoItem.MakeItDone();

            todoItem.MakeItUndone();

            todoItem.DoneDate.Should().BeNull();
        }
    }
}
