using Common.Events.Domain;

namespace Common.Events.Bus;
public interface IAppDomainEventHandler<TEvent> where TEvent : DomainEvent
{ //all classes containing App in their name will be renamed when the old event design has been more removed
    public void Handler(TEvent @event);
}
