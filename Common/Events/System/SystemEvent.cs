using Common.Events.Base;

namespace Common.Events.System;
public abstract class SystemEvent : IBaseEvent
{
    public string EventType { get; private set; }

    public Guid EventId { get; private set; }

    public long TimeStampRecorded { get; private set; }

    public Guid CorrelationId { get; private set; }

    public Guid CausationId { get; private set; }

    public SystemEvent(Guid correlationId, Guid causationId)
    {
        EventType = GetType().Name;
        EventId = Guid.NewGuid();
        TimeStampRecorded = DateTime.Now.Ticks;
        CorrelationId = correlationId;
        CausationId = causationId;
    }
}

public abstract class SystemEvent<TData> : SystemEvent
{
    public TData Data { get; private set; }

    public SystemEvent(TData data, Guid correlationId, Guid causationId) : base(correlationId, causationId)
    {
        Data = data;
    }
}
