using Common.Events.Domain;
using Common.Events.System;

namespace Common.Events.Bus;
internal interface IApplicationBus
{ //cannot overload with pure generic even if they are constrained to different abstract classes.
  //c sharp does not consider generic constrains to be part of the signature
    public void RegisterHandler(Action<SystemEvent> handler);
    public void Publish(SystemEvent @event);
    public void UnregisterHandler(Action<SystemEvent> handler);
    public void RegisterHandler(Action<DomainEvent> handler);
    public void Publish(DomainEvent @event);
    public void UnregisterHandler(Action<DomainEvent> handler);
}