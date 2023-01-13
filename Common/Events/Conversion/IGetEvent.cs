using Common.Events.Domain;
using Common.Events.Store.Event;

namespace Common.Events.Conversion;
public interface IGetEvent<TEvent> where TEvent : DomainEvent
{
    public static abstract IEnumerable<DataPoint> Get(TEvent @event);
}
