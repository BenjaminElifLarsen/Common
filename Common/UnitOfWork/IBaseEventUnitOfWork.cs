using Common.Events.System;

namespace Common.UnitOfWork;
public interface IBaseEventUnitOfWork
{
    public void AddSystemEvent(SystemEvent @event);
    public void ProcessEvents();
    public void Handle(SaveProcessedWork command);
    public void Handle(DiscardProcesssedWork command);
}
