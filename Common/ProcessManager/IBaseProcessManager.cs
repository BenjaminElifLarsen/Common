using Common.CQRS.Commands;
using Common.Events.State;

namespace Common.ProcessManager;
/// <summary>
/// Contract for a base procress manager.
/// </summary>
public interface IBaseProcessManager //new design
{
    public Guid ProcessManagerId { get; }
    public Guid CorrelationId { get; }
    //public abstract void SetUp(Guid correlationId);
    public Guid Versioning { get; }
    public IEnumerable<ICommand> Commands { get; }
    public IEnumerable<StateEvent> StateEvents { get; }
    public IEnumerable<string> Errors { get; }
    public void GenerateNewVersioning(); //should be called after validating the current versioning against the context
}
