using Common.Events.Domain;
using System.Text.Json;

namespace Common.Events.Store.Event;
public class Event<T>
{
    public T AggregateId { get; private set; }
    public string AggregateType { get; private set; }
    /// <summary>
    /// JSON string of the IDomainEvent
    /// </summary>
    public string Data { get; private set; }
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

    //public Event(int aggregateId, string aggregateType, string data, int version, string type, long timestamp, int sequenceNumber)
    //{
    //    AggregateId = aggregateId;
    //    AggregateType = aggregateType;
    //    Data = data;
    //    Version = version;
    //    Type = type;
    //    Timestamp = timestamp;
    //    SequenceNumber = sequenceNumber;
    //}

    public Event(DomainEvent<T> @event)
    {
        AggregateId = @event.AggregateId;
        AggregateType = @event.AggregateType;
        Type = @event.GetType().Name;
        Timestamp = @event.TimeStampRecorded;
        Version = @event.Version;
        Data = JsonSerializer.Serialize(@event);
    }
}

public class Event : Event<Guid>
{
    public Event(DomainEvent @event) : base(@event)
    {
    }
}
