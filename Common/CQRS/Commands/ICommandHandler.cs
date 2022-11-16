using Common.Events.Domain;
using Common.ResultPattern;

namespace Common.CQRS.Commands;
public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    public Result Handle(TCommand command);
}


public interface ICommandHandler<TCommand, TEvent> : ICommandHandler<TCommand> where TCommand : ICommand where TEvent : IDomainEvent
{
    public void EventAction(TEvent e); //consider moving this into its own Handler, IEventHandler, at some point
    //right now the {domain}CommandHandlers contain both command handlers and event handlers.
    //look into get the command bus done first before doing this. 
    //lucky it should not be to difficult to move the event handlers out and triggering commands, when the command busses are implemented.
}