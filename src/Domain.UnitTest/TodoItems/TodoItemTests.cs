using Domain.TodoItems;
using Faker;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.UnitTest.TodoItems
{
    public class TodoItemTests
    {
        private string TodoItemTitle => Name.FullName(NameFormats.WithPrefix);


        [Test]
        public void WhenTodoItemGetsDoneDateShouldBeUpdated()
        {
            var todoItem = new TodoItem(TodoItemTitle);

            todoItem.MakeItDone();

            todoItem.DoneDate.Should().Be(DateTime.UtcNow.Date);
        }

        [Test]
        public void WhenTodoItemGetsUndoneDateShouldBe()
        {
            var todoItem = new TodoItem(TodoItemTitle);

            todoItem.MakeItDone();

            todoItem.MakeItUndone();

            todoItem.DoneDate.Should().BeNull();
        }

        [Test]
        public void DueDateShouldBeSet()
        {
            var todoItem = new TodoItem(TodoItemTitle);

            var dueDate = DateTime.UtcNow.Date.AddDays(3);

            todoItem.SetDueDate(dueDate);

            todoItem.DueDate.Should().Be(dueDate);
        }

        [Test]
        public void TodoItemShouldNotBeConstructedWithoutTitle()
        {
            var action = () => new TodoItem(string.Empty);

            action.Should().Throw<TitleNullOrEmptyException>();
        }

        [Test]
        public void TodoItemTitleShouldNotBeMoreThanMaximumLengthLimit()
        {
            var invalidTitle = TodoItemTitle;

            for (int i = 0; i < TodoItem.MaximumTitleLength; i++)
                invalidTitle += "*";

            var action = () => new TodoItem(invalidTitle);

            action.Should().Throw<InvalidTitleLengthException>();
        }
    }
}
