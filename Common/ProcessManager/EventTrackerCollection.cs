using Common.Events.Domain;

namespace Common.ProcessManager;
/// <summary>
/// Used by process managers to know which events are requried or not and what the state of them are.
/// </summary>
public sealed class EventTrackerCollection //consider better name
{
    private readonly Dictionary<Type, EventTracker> _evnets;
    private readonly Dictionary<Type, MultiEventTracker> _multiEvents;

    public bool Failed => _evnets.Any(x => x.Value.Status == DomainEventStatus.Failed) || _multiEvents.Any(x => x.Value.Status == DomainEventStatus.Failed);
    public bool AllRequiredSucceded => _evnets.Where(x => x.Value.Required == true).All(x => x.Value.Status == DomainEventStatus.Completed) && _multiEvents.Where(x => x.Value.Required == true).All(x => x.Value.Status == DomainEventStatus.Completed);
    public bool AllFinishedOrFailed => _evnets.All(x => x.Value.Status == DomainEventStatus.Completed || x.Value.Status == DomainEventStatus.Failed) && _multiEvents.All(x => x.Value.Status == DomainEventStatus.Completed || x.Value.Status == DomainEventStatus.Failed);
    
    public EventTrackerCollection()
    {
        _evnets = new();
        _multiEvents = new();
    }

    public void AddEventTracker<TEvent>(bool requiredForCompletion) where TEvent : IDomainEvent
    {
        _evnets.TryAdd(typeof(TEvent), new(requiredForCompletion));
    }

    public void AddEventTracker<TEvent>(bool requiredForCompletion, int amount) where TEvent : IDomainEvent
    {
        _multiEvents.TryAdd(typeof(TEvent), new(requiredForCompletion, amount));
    }

    public void RemoveEvent<TEvent>()
    {
        _evnets.Remove(typeof(TEvent));
        _multiEvents.Remove(typeof(TEvent));
    }

    public void UpdateEvent<TEvent>(DomainEventStatus status) where TEvent : IDomainEvent
    {
        if (!_evnets.ContainsKey(typeof(TEvent)) && !_multiEvents.ContainsKey(typeof(TEvent)))
        {
            throw new Exception("Incorrect key.");
        }
        if (_evnets.ContainsKey(typeof(TEvent)))
        {
            _evnets[typeof(TEvent)].UpdateStatus(status);
        }
        else
        {
            _multiEvents[typeof(TEvent)].UpdateStatus(status);
        }
    }
}