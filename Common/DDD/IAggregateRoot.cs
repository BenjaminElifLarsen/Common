using Common.Events.Domain;

namespace Common.DDD;
/// <summary>
/// Contract for aggregate roots. 
/// </summary>
public interface IAggregateRoot<T>
{
    public T Id { get; }
    /// <summary>
    /// Get all events related to this aggregate.
    /// </summary>
    public IEnumerable<DomainEvent> Events { get; }
    /// <summary>
    /// Add an event to the aggregate.
    /// </summary>
    /// <param name="eventItem"></param>
    public void AddDomainEvent(DomainEvent eventItem);
    /// <summary>
    /// Remove an event from the aggregate. 
    /// </summary>
    /// <param name="eventItem"></param>
    public void RemoveDomainEvent(DomainEvent eventItem);
}

public interface IAggregateRoot : IAggregateRoot<Guid>
{

}