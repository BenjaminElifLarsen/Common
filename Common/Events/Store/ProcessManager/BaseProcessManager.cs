namespace Common.Events.Store.ProcessManager;
public abstract class BaseProcessManager
{
    public abstract Guid ProcessManagerId { get; }
    public abstract Guid CorrelationId { get; }
    public abstract void SetUp(Guid correlationId);
}
