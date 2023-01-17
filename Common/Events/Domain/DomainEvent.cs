using Common.Events.Base;
using Common.Events.Store.Event;
using Common.RepositoryPattern;

namespace Common.Events.Domain;

public abstract record DomainEvent<T> : IBaseEvent, IDomainEvent<T>
{
    public string EventType { get; private set; }

    public Guid EventId { get; private set; }

    public long TimeStampRecorded { get; private set; }

    public Guid CorrelationId { get; private set; }

    public Guid CausationId { get; private set; }
    public string AggregateType { get; private set; }
    public T AggregateId { get; private set; }
    public int Version { get; private set; }

    protected DomainEvent(T aggregateId, string aggregateType, int version, Guid correlationId, Guid causationId)
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

    public DomainEvent(IAggregateRoot<T> aggregate, Guid correlationId, Guid causationId)
        : this(aggregate.Id, aggregate.GetType().Name, aggregate.Events.Count(), correlationId, causationId)
    {

    }

    public DomainEvent(Event<T> e)
    {
        EventId = e.DomainEventId;
        EventType = e.Type;
        AggregateId = e.AggregateId;
        Version = e.Version;
        CorrelationId = e.CorrelationId;
        CausationId = e.CausationId;
        AggregateType = e.AggregateType;
        TimeStampRecorded = e.Timestamp;
    }

    public abstract Event ConvertToEvent();
}

public abstract record DomainEvent : DomainEvent<Guid>
{
    protected DomainEvent(IAggregateRoot aggregate, Guid correlationId, Guid causationId) 
        : base(aggregate, correlationId, causationId)
    {
    }

    protected DomainEvent(Event e) : base(e)
    {
    }
}