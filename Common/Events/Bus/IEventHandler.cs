using Common.Events.Base;
using Common.Events.Domain;

namespace Common.Events.Bus;
public interface IEventHandler<TEvent> where TEvent : IBaseEvent
{ //all classes containing App in their name will be renamed when the old event design has been more removed
    public void Handle(TEvent @event);
}
