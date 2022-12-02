using Common.Events.Domain;

namespace Common.RepositoryPattern;
public interface IBaseEventUnitOfWork
{
    public void AddOrphanEvnet(IDomainEvent @event);
    public void ProcessEvents();
}
