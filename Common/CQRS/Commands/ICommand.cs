namespace Common.CQRS.Commands;
/// <summary>
/// Contract for a command. To be used with <c>ICommandHandler</c> and <c>ICommandBus</c>
/// </summary>
public interface ICommand
{
    public Guid CommandId { get; }
    public Guid CorrelationId { get; }
    public Guid CausationId { get; }
}
