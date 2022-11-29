using Common.Events.Domain;

namespace Common.ProcessManager;
public interface IProcessManager
{
    public Guid ProcessManagerId { get; }
    public Guid CorrelationId { get; }
}
