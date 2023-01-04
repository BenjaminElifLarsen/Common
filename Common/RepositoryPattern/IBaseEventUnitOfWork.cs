using Common.Events.System;

namespace Common.RepositoryPattern;
public interface IBaseEventUnitOfWork
{
    public void AddSystemEvent(SystemEvent @event);
    public void ProcessEvents();
}
