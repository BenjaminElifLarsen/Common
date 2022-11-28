using Common.Events.Domain;

namespace Common.ProcessManager;
public interface IProcessManagerEventHandler<TEvent> where TEvent : IDomainEvent
{
    void Handler(TEvent @event);
}
