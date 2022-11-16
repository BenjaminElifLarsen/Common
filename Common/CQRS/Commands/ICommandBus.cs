namespace Common.CQRS.Commands;
public interface ICommandBus
{ //the registration method need to ensure each command only has a single handle
    public void RegisterHandler<T>(Action<T> handler) where T : ICommand;
    public void Publish<T>(T command) where T : ICommand;
    public void UnregisterHandler<T>(Action<T> handler) where T : ICommand;
}
