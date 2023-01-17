namespace Common.ProcessManager;

internal enum DomainEventStatus  //old design
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