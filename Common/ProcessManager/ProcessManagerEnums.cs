namespace Common.ProcessManager;

internal enum DomainEventStatus
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