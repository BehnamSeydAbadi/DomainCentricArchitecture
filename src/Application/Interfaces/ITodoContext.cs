using Domain.TodoItems;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface ITodoContext
    {
        DbSet<TodoItem> Customers { get; set; }
    }
}
