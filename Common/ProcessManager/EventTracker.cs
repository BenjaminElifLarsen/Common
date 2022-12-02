namespace Common.ProcessManager;
public sealed class EventTracker //consider better name and move
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
