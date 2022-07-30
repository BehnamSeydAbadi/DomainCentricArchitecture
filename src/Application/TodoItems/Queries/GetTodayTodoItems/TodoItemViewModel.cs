namespace Application.TodoItems.Queries.GetTodayTodoItems
{
    public class TodoItemViewModel
    {
        public TodoItemViewModel(string title, bool isDone, DateTime? doneDate, DateTime? dueDate)
        {
            Title = title;
            IsDone = isDone;
            DoneDate = doneDate;
            DueDate = dueDate;
        }

        public string Title { get; }
        public bool IsDone { get; }
        public DateTime? DoneDate { get; }
        public DateTime? DueDate { get; }
    }
}
