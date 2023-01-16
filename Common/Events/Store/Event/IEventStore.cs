using Common.RepositoryPattern;

namespace Common.Events.Store.Event;
public interface IEventStore<TId>
{ //from reading it seems like repositories should write data to the store.
    //can either have an event store for the entire system or for each application
    /// <summary>
    /// Get all events that points to <paramref name="aggregateId"/> and <paramref name="aggregateType"/> ordered by <c>Version</c>
    /// </summary>
    /// <param name="aggregateId"></param>
    /// <param name="aggregateType"></param>
    /// <returns></returns>
    //Task<IEnumerable<Event>> EventsAsync(int aggregateId, string aggregateType);
    //Task<IEnumerable<DomainEvent>> DoaminEventsAsync(int aggregateId, string aggregateType);
    //Task Add(Aggregate aggregate);
    //Task Add(Event @event);
    //void Save(); //how to deal with snapshots
    //how to implement the snap shotter processer. Loads up any aggregate root that require a snapshot, snapshots it, and stores the snapshot 
    //https://cqrs.wordpress.com/documents/building-event-storage/
    //maybe snapshot part would be better be implemnted in the concreate without any contract methods
    Task<IEnumerable<Event<TId>>> LoadStreamAsync(TId id, string aggregateType); 
    /*
     * if using memento pattern, the first data point should be the snapshot, anything after should be the events, but how to best do this?
     * could convert the snapshot the an event of a special type like 'CreateEvent'.
     * the ctors of the aggregate roots should understand how to convert the events to types they can use (the data is stored in json afterall)
     */
    Task<IEnumerable<Event<TId>>> LoadStreamAsync(TId id, string aggregateType, DateTime endTime);
    //void AddEvents(IAggregateRoot aggregate);
    Task<IEnumerable<Event<TId>>> LoadStreamAsync(string aggregateType);
    void AddEvent(Event<TId> @event);
    void AddEvents(IEnumerable<Event<TId>> events);
    //Task<Event> GetEvent(int sequenceNumber);
} //consider adding the rolling snapshot with the memento pattern (read up on that)
  //https://cqrs.wordpress.com/documents/building-event-storage/

//https://stackoverflow.com/questions/12362641/relation-between-command-handlers-aggregates-the-repository-and-the-event-stor?rq=1