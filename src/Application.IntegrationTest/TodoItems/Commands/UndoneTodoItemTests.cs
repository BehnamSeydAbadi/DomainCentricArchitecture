using Application.TodoItems.Commands.Common;
using Application.TodoItems.Commands.UndoneTodoItem;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using NUnit.Framework;

namespace Application.UnitTest.TodoItems.Commands
{
    public class UndoneTodoItemTests : BaseTest
    {
        //private UndoneTodoItemCommandHandler _commandHandler;

        //[SetUp]
        //public void Setup() => _commandHandler = new UndoneTodoItemCommandHandler(_todoContext);

        //[Test]
        //public async Task DoneDateShouldBeNullWhenTodoItemGetsUndoneAsync()
        //{
        //    //Arange
        //    var todoItem = new TodoItem(RandomTodoItemTitle);

        //    await _todoContext.TodoItems.AddAsync(todoItem);
        //    await _todoContext.SaveChangesAsync();


        //    //Act
        //    await _commandHandler.HandleAsync(new UndoneTodoItemCommand(todoItem.Id));


        //    //Arange
        //    todoItem.DoneDate.Should().BeNull();
        //}

        //[Test]
        //public async Task ThrowExceptionWhenTodoItemNotFoundAsync()
        //{
        //    var action = () => _commandHandler.HandleAsync(new UndoneTodoItemCommand(0));

        //    await action.Should().ThrowAsync<TodoItemNotFoundException>();
        //}
    }
}
