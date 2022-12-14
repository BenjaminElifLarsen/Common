namespace Common.ProcessManager;

internal sealed class EventState
{
    public bool Required { get; private set; }
    public DomainEventStatus Status { get; private set; }
    public DomainEventType Type { get; private set; }

    public EventState(bool required, DomainEventType type)
    {
        Required = required;
        Status = DomainEventStatus.Awaiting;
        Type = type;
    }

    public void UpdateStatus(DomainEventStatus status)
    {
        Status = status;
    }
}