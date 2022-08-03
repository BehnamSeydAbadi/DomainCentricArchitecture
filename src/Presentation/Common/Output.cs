namespace Presentation.Common
{
    public sealed class Output
    {
        private Output(object? data, Error? error)
        {
            if (data is null && error is null)
                throw new InvalidOperationException("Output should not be empty of data and error.");
            
            Data = data;
            Error = error;
        }

        public static Output Create(object data) => new(data, null);
        public static Output Create(Error error) => new Output(null, error);

        public object? Data { get; private set; }
        public Error? Error { get; private set; }
    }

    public class Error
    {
        private Error(string title, string[] details)
        {
            ValidateTitle(title);

            Title = title;
            Details = details;
        }

        public static Error Create(string title) => new Error(title, Array.Empty<string>());
        public static Error Create(string title, string detail) => new Error(title, new[] { detail });
        public static Error Create(string title, string[] details) => new Error(title, details);

        public string Title { get; private set; }
        public string[] Details { get; private set; } = Array.Empty<string>();

        private void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));
        }
    }
}
