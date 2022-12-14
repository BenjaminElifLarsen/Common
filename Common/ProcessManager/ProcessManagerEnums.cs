namespace Common.ProcessManager;

public enum DomainEventStatus
{
    Awaiting,
    Completed,
    Failed,
    Removed,
}

public enum DomainEventType
{
    Succeeder,
    Failer,
}