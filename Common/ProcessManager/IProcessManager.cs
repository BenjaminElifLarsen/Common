using Common.ResultPattern;

namespace Common.ProcessManager;
public interface IProcessManager
{
    public Guid ProcessManagerId { get; }
    public Guid CorrelationId { get; }
    public bool Running { get; }
    public bool FinishedSuccessful { get; }
    public void SetUp(Guid correlationId);
    public void SetCallback(Action<Result> callback);
    public void RunCallbackIfPossible();
}
