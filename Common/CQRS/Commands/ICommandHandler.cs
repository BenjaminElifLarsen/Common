using Common.ResultPattern;

namespace Common.CQRS.Commands;
public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    public Result Handle(TCommand command);
}
