using Common.Events.Domain;
using Common.ResultPattern;

namespace Common.CQRS.Commands;
public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    public Result Handle(TCommand command);
}


public interface ICommandHandler<TCommand, TEvent> : ICommandHandler<TCommand> where TCommand : ICommand where TEvent : IDomainEvent
{
    public void EventAction(TEvent e);
}