using Common.Events.Base;

namespace Common.Events.Domain;
public abstract class DomainEvent : IBaseEvent
{
    public string EventType { get; protected set; }

    public Guid EventId { get; protected set; }

    public long TimeStampRecorded { get; protected set; }

    public Guid CorrelationId { get; protected set; }

    public Guid CausationId { get; protected set; }
    public string AggregateType { get; protected set; }
    public int AggregateId { get; protected set; }
    public int Version { get; protected set; }

    public DomainEvent(Guid correlationId, Guid causationId)
    {
        EventType = GetType().Name;
        EventId = Guid.NewGuid();
        TimeStampRecorded = DateTime.Now.Ticks;
        CorrelationId = correlationId;
        CausationId = causationId;
    }
}

//not sure there is a point for this class, concrete implementations of the above abstract could add the data properties as needed
//the same for error messages, maybe error version actually should be of EventType rather than DomainEvent.
//public abstract class DomainEvent<TData> : DomainEvent
//{ //use for data
//    public TData Data { get; protected set; }

//    public DomainEvent(TData data, Guid correlationId, Guid causationId) : base(correlationId, causationId)
//    {
//        Data = data;
//    }
//}