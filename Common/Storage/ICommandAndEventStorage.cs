using Common.CQRS.Commands;
using Common.Events.Base;
using Common.Events.Store.Event;

namespace Common.Storage;

public interface ICommandAndEventStorage
{

    public void Add(ICommand command);

    public void Add(IBaseEvent @event);

    public bool Process();
}