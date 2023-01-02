namespace Common.Events.Store.Event;
public class Event
{
    public int AggregateId { get; private set; }
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
    public int SequenceNumber { get; private set; }

    public Event(int aggregateId, string data, int version, string type, long timestamp, int sequenceNumber)
    {
        AggregateId = aggregateId;
        Data = data;
        Version = version;
        Type = type;
        Timestamp = timestamp;
        SequenceNumber = sequenceNumber;
    }
}
