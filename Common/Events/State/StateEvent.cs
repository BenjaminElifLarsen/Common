using Common.Events.System;

namespace Common.Events.State;
public record StateEvent : SystemEvent
{
    public StateEvent(Guid correlationId, Guid causationId) : base(correlationId, causationId)
    {
    }
}
