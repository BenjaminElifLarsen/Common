using Common.Events.Store.Event;

namespace Common.RepositoryPattern.Events;
public interface IBaseEventRepository<TId>
{
    public void AddEvents(IEnumerable<Event> events);
    //public void AddSnapshoot(IMemento memento);
    public Task<IEnumerable<Event<TId>>> LoadEntityEventsAsync(TId id);
    public Task<IEnumerable<Event<TId>>> LoadEntityEventsUptoAsync(TId id, DateTime UpTo);
    //replay method?

}

