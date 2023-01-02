using Common.Events.Base;
using System.Text.Json;

namespace Common.Events.Domain;
public abstract class DomainEvent : IBaseEvent
{
    public string EventType { get; private set; }

    public Guid EventId { get; private set; }

    public long TimeStampRecorded { get; private set; }

    public Guid CorrelationId { get; private set; }

    public Guid CausationId { get; private set; }
    public string AggregateType { get; private set; }
    public int AggregateId { get; private set; }
    public int Version { get; private set; }

    public DomainEvent(Guid correlationId, Guid causationId)
    {
        EventType = GetType().Name;
        EventId = Guid.NewGuid();
        TimeStampRecorded = DateTime.Now.Ticks;
        CorrelationId = correlationId;
        CausationId = causationId;
    }
}

public abstract class DomainEvent<TData> : DomainEvent where TData : class
{
    public TData Data { get; private set; }

    public DomainEvent(TData data, Guid correlationId, Guid causationId) : base(correlationId, causationId)
    {
        Data = data;
    }
}