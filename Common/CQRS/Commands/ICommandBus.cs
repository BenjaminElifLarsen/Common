using Common.ResultPattern;

namespace Common.CQRS.Commands;
/// <summary>
/// Contract for a command bus designed to return <c>Result</c>.
/// </summary>
public interface ICommandBus
{
    /// <summary>
    /// Registrates a function of <c>ICommand</c>.
    /// </summary>
    /// <typeparam name="T">Implementation of <c>ICommand.</c></typeparam>
    /// <param name="handler">The handler to trigger.</param>
    public void RegisterHandler<T>(Action<T> handler) where T : ICommand;
    /// <summary>
    /// Publish a <c>ICommand</c>.
    /// </summary>
    /// <typeparam name="T">Implementation of <c>ICommand</c>.</typeparam>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    public Result Dispatch<T>(T command) where T : ICommand;
    /// <summary>
    /// Unrigistrates a function of <c>ICommand</c>.
    /// </summary>
    /// <typeparam name="T">Implementation of <c>ICommand</c>.</typeparam>
    /// <param name="handler">The handler to trigger.</param>
    public void UnregisterHandler<T>(Action<T> handler) where T : ICommand;
}
