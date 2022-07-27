namespace Domain.TodoItems
{
    public sealed class TodoItem
    {
        public bool IsDone { get; private set; }
        public DateTime? DoneDate { get; private set; }

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
    }
}
