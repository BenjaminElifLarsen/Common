using Common.Events.Domain; 

namespace Common.RepositoryPattern;
/// <summary>
/// Contract for aggregate roots. 
/// </summary>
public interface IAggregateRoot
{
    public int Id { get; set; }
    /// <summary>
    /// Get all events related to this aggregate.
    /// </summary>
    public IEnumerable<IDomainEvent> Events { get; }
    /// <summary>
    /// Add an event to the aggregate.
    /// </summary>
    /// <param name="eventItem"></param>
    public void AddDomainEvent(IDomainEvent eventItem);
    /// <summary>
    /// Remove an event from the aggregate. 
    /// </summary>
    /// <param name="eventItem"></param>
    public void RemoveDomainEvent(IDomainEvent eventItem);
    public void AddDomainEvent(DomainEvent eventItem);
    public IEnumerable<DomainEvent> GetEvents { get; }
}
