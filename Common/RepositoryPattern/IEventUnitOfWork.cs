using Common.Events.Domain;

namespace Common.RepositoryPattern;
public interface IEventUnitOfWork
{
    public void AddOrphanEvnet(IDomainEvent @event);
    public void ProcessEvents();
}
