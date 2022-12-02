using Common.Events.Domain;

namespace Common.ProcessManager;

public enum DomainEventStatus
{
    Awaiting,
    Completed,
    Failed,
}

/// <summary>
/// Used by process managers to know which events are requried or not and what the state of them are.
/// </summary>
public class EventTrackerCollection //consider better name and move
{
    protected Dictionary<Type, EventTracker> _evnets;

    public bool Failed => _evnets.Any(x => x.Value.Status == DomainEventStatus.Failed);
    public bool AllRequiredSucceded => _evnets.Where(x => x.Value.Required == true).All(x => x.Value.Status == DomainEventStatus.Completed);
    public bool AllFinishedOrFailed => _evnets.All(x => x.Value.Status == DomainEventStatus.Completed || x.Value.Status == DomainEventStatus.Failed);
    public EventTrackerCollection()
    {
        _evnets = new();
    }

    public void AddEventTracker<TEvent>(bool requiredForCompletion) where TEvent : IDomainEvent
    {
        _evnets.TryAdd(typeof(TEvent), new(requiredForCompletion));
    }

    public void RemoveEvent<TEvent>()
    {
        _evnets.Remove(typeof(TEvent));
    }

    public void UpdateEvent<TEvent>(DomainEventStatus status) where TEvent : IDomainEvent
    {
        if (!_evnets.ContainsKey(typeof(TEvent)))
        {
            throw new Exception("Incorrect key.");
        }
        _evnets[typeof(TEvent)].UpdateStatus(status);
    }
}

public class EventTracker //consider better name and move
{
    public bool Required { get; private set; }
    public DomainEventStatus Status { get; private set; }

    public EventTracker(bool required)
    {
        Required = required;
        Status = DomainEventStatus.Awaiting;
    }

    public void UpdateStatus(DomainEventStatus status)
    {
        Status = status;
    }
}