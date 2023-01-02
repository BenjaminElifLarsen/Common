using Common.Events.Domain;

namespace Common.Events.Bus;
public interface IAppDomainEventHandler<TEvent> where TEvent : DomainEvent
{
    public void Handle(TEvent @event);
}
