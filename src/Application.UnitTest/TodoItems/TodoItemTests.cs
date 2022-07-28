using Application.Interfaces;
using Domain.TodoItems;
using Faker;
using Moq;
using NUnit.Framework;

namespace Application.UnitTest.TodoItems
{
    public class TodoItemTests
    {
        private readonly Mock<ITodoContext> _todoContext = new Mock<ITodoContext>();

        private string TodoItemTitle => Name.FullName(NameFormats.WithPrefix);

        [SetUp]
        public void Setup()
        {
            var fakeTodoItems = new[]
            {
                new TodoItem(TodoItemTitle),
                new TodoItem(TodoItemTitle),
                new TodoItem(TodoItemTitle)
            };

            _todoContext.Setup(c => c.TodoItems.AddRange(fakeTodoItems));
        }

        [Test]
        public void GetTodayTodoItemsSuccessfully()
        {
            var ererer = _todoContext.Object.TodoItems.ToList();
        }
    }
}
