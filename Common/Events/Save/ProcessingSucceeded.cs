using Common.Events.System;

namespace Common.Events.Save;
/// <summary>
/// The processing task was a success.
/// </summary>
public sealed record ProcessingSucceeded : SystemEvent
{
    public ProcessingSucceeded(Guid correlationId, Guid causationId) : base(correlationId, causationId)
    {
    }
}
