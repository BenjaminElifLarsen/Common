using Common.Events.System;

namespace Common.Events.Save;
/// <summary>
/// The processing task was a failer.
/// </summary>
public sealed record ProcessingFailed : SystemEvent
{
    public IEnumerable<string> Errors { get; private set; }
    public ProcessingFailed(IEnumerable<string> errors, Guid correlationId, Guid causationId) : base(correlationId, causationId)
    {
        Errors = errors;
    }
}
