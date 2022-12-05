namespace Common.ProcessManager;

public sealed class EventTracker //consider better name
{
    public bool Required { get; private set; }
    public DomainEventStatus Status { get; private set; }

    public EventTracker(bool required)
    {
        Required = required;
        Status = DomainEventStatus.Awaiting;
    }

    public void UpdateStatus(DomainEventStatus status)
    {
        Status = status;
    }
}
/*
 * maybe have a single event (instead of tracking 15 failers and successes) that states which failed, e.g. which operators was not found and needs to be removed from license type.
 * while also containing the ids of those which no longer are valid.
 */
