using Common.Events.Domain;
using System.Text.Json;

namespace Common.Events.Store.Event;
public class Event<T>
{
    public T AggregateId { get; private set; }
    public string AggregateType { get; private set; }
    ///// <summary>
    ///// JSON string of the IDomainEvent
    ///// </summary>
    //public string Data { get; private set; }
    public IEnumerable<DataPoint> Data { get; private set; }
    public int Version { get; private set; }
    /// <summary>
    /// The IDomainEvent type.
    /// </summary>
    public string Type { get; private set; }
    public long Timestamp { get; private set; }
    /// <summary>
    /// Used by a chasing process to publish events to other streams, permitting the event storage to act as a queue.
    /// </summary>
    public long SequenceNumber { get; private set; } //sat by the context, unique and incrementing
    public EventType EventType { get; private set; }
    public Guid CorrelationId { get; private set; }
    public Guid CausationId { get; private set; }
    public Guid DomainEventId { get; private set; }

    internal Event()
    { // ORM 

    }

    public Event(DomainEvent<T> @event, IEnumerable<DataPoint> data)
    {
        AggregateId = @event.AggregateId;
        AggregateType = @event.AggregateType;
        Type = @event.GetType().Name;
        Timestamp = @event.TimeStampRecorded;
        //Version = @event.Version;
        Data = data is not null ? data : new List<DataPoint>();
        //Data = JsonSerializer.Serialize(@event);
        CorrelationId = @event.CorrelationId;
        CausationId = @event.CausationId;
        DomainEventId = @event.EventId;
    }

    public Event(DomainEvent<T> @event, IEnumerable<DataPoint> data, EventType eventType) : this(@event, data)
    {
        EventType = eventType;
    }

    internal Event(Event<T> e)
    {
        AggregateId = e.AggregateId;
        AggregateType = e.AggregateType;
        Type = e.Type;
        Timestamp = e.Timestamp;
        //Version = e.Version;
        Data = e.Data;
        CorrelationId = e.CorrelationId;
        CausationId = e.CausationId;
        DomainEventId = e.DomainEventId;
    }

    public void SetVersion(int version)
    {
        Version = version;
    }
}

public sealed class Event : Event<Guid>
{
    public Event(DomainEvent @event, IEnumerable<DataPoint> data) : base(@event, data)
    {
    }

    public Event(DomainEvent @event, IEnumerable<DataPoint> data, EventType eventType) : base(@event, data, eventType)
    {
    }

    internal Event(Event<Guid> e) : base(e)
    {
    }

    public static Event EventFromGeneric(Event<Guid> e)
    {
        return new(e);
    }
}
