namespace Common.Events.Base;
public interface IEventBus
{
    public void RegisterHandler<T>(Action<T> handler) where T : IBaseEvent;
    public void Publish<T>(T @event) where T : IBaseEvent;
    public void UnregisterHandler<T>(Action<T> handler) where T : IBaseEvent;
}
