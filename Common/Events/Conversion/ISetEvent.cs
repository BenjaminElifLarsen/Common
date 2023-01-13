using Common.Events.Domain;
using Common.Events.Store.Event;

namespace Common.Events.Conversion;
public interface ISetEvent
{
    public static abstract DomainEvent Set(Event @event);
}
