using Common.ResultPattern;

namespace Common.CQRS.Commands;
public interface ICommandHandler<TCommand>
{
    public Result<int> Handle(TCommand command);
}
