namespace Common.Events.Domain;
public interface IDomainEventBus
{
    public void RegisterHandler<T>(Action<T> handler) where T : IDomainEvent;
    public void Publish<T>(T @event) where T : IDomainEvent;
    public void UnregisterHandler<T>(Action<T> handler) where T : IDomainEvent;
}
