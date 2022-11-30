using Common.Events.Domain;

namespace Common.Events.Store;
public interface IEventStore
{ //from reading it seems like repositories should write data to the store.
    //can either have an event store for the entire system or for each application
    /// <summary>
    /// Get all events that points to <paramref name="aggregateId"/> and <paramref name="aggregateType"/> ordered by <c>Version</c>
    /// </summary>
    /// <param name="aggregateId"></param>
    /// <param name="aggregateType"></param>
    /// <returns></returns>
    Task<IEnumerable<Event>> EventsAsync(int aggregateId, string aggregateType);
    Task<IEnumerable<IDomainEvent>> DoaminEventsAsync(int aggregateId, string aggregateType);
    Task Add(Aggregate aggregate);
    Task Add(Event @event);
    void Save();
    Task<Event> GetEvent(int sequenceNumber);
} //consider adding the rolling snapshot with the memento pattern (read up on that)
  //https://cqrs.wordpress.com/documents/building-event-storage/