namespace Common.ProcessManager;
public interface IProcessManager
{
    public Guid ProcessManagerId { get; }
    public Guid CorrelationId { get; }

    public void SetUp(Guid correlationId);
}
