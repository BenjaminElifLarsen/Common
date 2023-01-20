using Common.CQRS.Commands;

namespace Common.UnitOfWork;
public sealed class DiscardProcesssedWork : ICommand
{
    public Guid CommandId { get; private set; }

    public Guid CorrelationId { get; private set; }

    public Guid CausationId { get; private set; }

    public IEnumerable<string> Errors { get; private set; }

    public DiscardProcesssedWork(IEnumerable<string> errors, Guid correlationId, Guid causationId)
    {
        CorrelationId = correlationId;
        CausationId = causationId;
        CommandId = Guid.NewGuid();
        Errors = errors;
    }
}
