namespace Common.RepositoryPattern.Events;
public interface IBaseEventRepository<TEntity> where TEntity : IAggregateRoot
{
    public void AddEvents(IAggregateRoot root);
    //public void AddSnapshoot(IMemento memento);
    public Task<TEntity> GetEntityAsync(int id);
    public Task<TEntity> GetEntityAsync(int id, DateTime UpTo);
    //replay method?

}
