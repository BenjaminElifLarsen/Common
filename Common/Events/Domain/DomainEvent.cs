using Common.Events.Base;

namespace Common.Events.Domain;
public abstract record DomainEvent : IBaseEvent
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