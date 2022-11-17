using Common.ResultPattern;

namespace Common.CQRS.Commands;
/// <summary>
/// Contract for a command handler. Can be triggered via the <c>ICommandBus,</c>
/// </summary>
/// <typeparam name="TCommand">The command.</typeparam>
public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    public Result Handle(TCommand command);
}
