using Common.ResultPattern;

namespace Common.CQRS.Commands;
public interface ICommandBus
{ //the registration method need to ensure each command only has a single handle
    public void RegisterHandler<T>(Func<T, Result> handler) where T : ICommand;
    public Result Publish<T>(T command) where T : ICommand;
    public void UnregisterHandler<T>(Func<T, Result> handler) where T : ICommand;
}
