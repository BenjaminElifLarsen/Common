using Common.Events.Store.Event;

namespace Common.RepositoryPattern.Events;
public interface IBaseEventRepository<TId>
{
    public void AddEvents(IEnumerable<Event<TId>> events);
    //public void AddSnapshoot(IMemento memento);
    public Task<IEnumerable<Event<TId>>> LoadEntityEventsAsync(TId id, string aggregateType);
    public Task<IEnumerable<Event<TId>>> LoadEntityEventsUptoAsync(TId id, string aggregateType, DateTime UpTo);
    //replay method?
    public Task<IEnumerable<Event<TId>>> LoadAllEvents(string aggregateType);
}

