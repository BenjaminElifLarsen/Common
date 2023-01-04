using Common.Events.Base;
using Common.RepositoryPattern;

namespace Common.Events.Domain;
public abstract record DomainEvent : IBaseEvent
{
    public string EventType { get; private set; }

    public Guid EventId { get; private set; }

    public long TimeStampRecorded { get; private set; }

    public Guid CorrelationId { get; private set; }

    public Guid CausationId { get; private set; }
    public string AggregateType { get; private set; }
    public int AggregateId { get; private set; }
    public int Version { get; private set; }

    private DomainEvent(int aggregateId, string aggregateType, int version, Guid correlationId, Guid causationId)
    {
        EventType = GetType().Name;
        EventId = Guid.NewGuid();
        TimeStampRecorded = DateTime.Now.Ticks;
        CorrelationId = correlationId;
        CausationId = causationId;
        AggregateType = aggregateType;
        AggregateId = aggregateId;
        Version = version;
    }

    public DomainEvent(IAggregateRoot aggregate, Guid correlationId, Guid causationId)
        : this(aggregate.Id, aggregate.GetType().Name, aggregate.Events.Count(), correlationId, causationId)
    {

    }
}