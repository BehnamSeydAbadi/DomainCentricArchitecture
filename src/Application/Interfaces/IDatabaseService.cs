using Domain.TodoItems;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<TodoItem> Customers { get; set; }
    }
}
