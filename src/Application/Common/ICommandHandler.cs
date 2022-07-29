namespace Application.Common
{
    public interface ICommandHandler<TCommand>
    {
        Task HandleAsync(TCommand command);
    }
}