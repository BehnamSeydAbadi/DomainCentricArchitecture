using Application.TodoItems.Commands.Common;
using Application.TodoItems.Commands.DeleteTodoItem;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.UnitTest.TodoItems.Commands
{
    public class DeleteTodoitemTests : BaseTest
    {
        //private DeleteTodoItemCommandHandler _commandHandler;

        //[SetUp]
        //public void Setup() => _commandHandler = new DeleteTodoItemCommandHandler(_todoContext);

        //[Test]
        //public async Task DeleteTodoItemSuccessfullyAsync()
        //{
        //    //Arange
        //    var todoItem = new TodoItem(RandomTodoItemTitle);

        //    await _todoContext.AddAsync(todoItem);
        //    await _todoContext.SaveChangesAsync();


        //    //Act
        //    await _commandHandler.HandleAsync(new DeleteTodoItemCommand(todoItem.Id));


        //    //Assert
        //    var todoItems = await _todoContext.TodoItems.ToListAsync();
        //    todoItems.Should().BeEmpty();
        //}

        //[Test]
        //public async Task ThrowExceptionWhenTodoItemNotFoundAsync()
        //{
        //    var action = () => _commandHandler.HandleAsync(new DeleteTodoItemCommand(0));

        //    await action.Should().ThrowAsync<TodoItemNotFoundException>();
        //}

    }
}
