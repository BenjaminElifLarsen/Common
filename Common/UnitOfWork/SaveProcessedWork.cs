using Common.CQRS.Commands;

namespace Common.UnitOfWork;
public sealed class SaveProcessedWork : ICommand
{
    public Guid CommandId { get; private set; }

    public Guid CorrelationId { get; private set; }

    public Guid CausationId { get; private set; }

    public SaveProcessedWork(Guid correlationId, Guid causationId)
    {
        CorrelationId = correlationId;
        CausationId = causationId;
        CommandId = Guid.NewGuid();
    }
}
