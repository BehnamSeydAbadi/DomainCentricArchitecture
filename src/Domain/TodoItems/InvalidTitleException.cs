namespace Domain.TodoItems
{
    public class InvalidTitleLengthException : Exception
    {
        public InvalidTitleLengthException() 
            : base($"Title length should not be more than {TodoItem.MaximumTitleLength} characters.") { }
    }
}