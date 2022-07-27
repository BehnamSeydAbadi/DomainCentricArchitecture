namespace Domain.TodoItems
{
    public sealed class TodoItem
    {
        public TodoItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new TitleNullOrEmptyException(nameof(title));


            Title = title;
        }

        public string Title { get; }
        public bool IsDone { get; private set; }
        public DateTime? DoneDate { get; private set; }
        public DateTime? DueDate { get; private set; }

        public void MakeItDone()
        {
            IsDone = true;
            DoneDate = DateTime.UtcNow.Date;
        }

        public void MakeItUndone()
        {
            IsDone = false;
            DoneDate = null;
        }

        public void SetDueDate(DateTime dueDate) => DueDate = dueDate;
    }
}
