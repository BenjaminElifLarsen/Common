using Common.Events.Domain;
using Common.MementoPattern;

namespace Common.RepositoryPattern.Event;
public interface IBaseEventRepository<TEntity>  where TEntity : IAggregateRoot
{
    public void AddEvent(DomainEvent @event);
    public void AddSnapshoot(IMemento memento);
    public Task<TEntity> GetEntityAsync(int id);
    public Task<TEntity> GetEntityAsync(int id, DateTime UpTo);
    //replay method?

}
