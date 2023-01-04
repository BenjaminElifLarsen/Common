using Common.Events.Base;

namespace Common.Events.Bus;
public interface IApplicationBus
{ 
    public void RegisterHandler<T>(Action<T> handler) where T : IBaseEvent;
    public void Publish<T>(T @event) where T : IBaseEvent;
    public void UnregisterHandler<T>(Action<T> handler) where T : IBaseEvent;
}