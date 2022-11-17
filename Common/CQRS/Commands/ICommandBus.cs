using Common.ResultPattern;

namespace Common.CQRS.Commands;
public interface ICommandBus
{ //the registration method need to ensure each command only has a single handle
    public void RegisterHandler<T>(Func<T, Result> handler) where T : ICommand; //action does not permit returning data and it could be useful to return a Result
    public Result Publish<T>(T command) where T : ICommand; //consider switching to Func for the command part
    public void UnregisterHandler<T>(Func<T, Result> handler) where T : ICommand;
}
