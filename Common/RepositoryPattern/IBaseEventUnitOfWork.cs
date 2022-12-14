using Common.Events.Domain;

namespace Common.RepositoryPattern;
public interface IBaseEventUnitOfWork
{
    public void AddOrphanEvent(IDomainEvent @event);
    public void ProcessEvents();
}
