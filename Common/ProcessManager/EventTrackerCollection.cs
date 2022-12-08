using Common.Events.Domain;
using System;
namespace Common.ProcessManager;
/// <summary>
/// Used by process managers to know which events are requried or not and what the state of them are.
/// </summary>
public sealed class EventTrackerCollection //consider better name and move
{
    protected Dictionary<Type, IEnumerable<EventTracker>> _events;

    public bool Failed => _events.SelectMany(x => x.Value).Any(x => x.Status == DomainEventStatus.Failed);
    public bool AllRequiredSucceded => _events.SelectMany(x => x.Value).Where(x => x.Required == true).All(x => x.Status == DomainEventStatus.Completed);
    public bool AllFinishedOrFailed => _events.SelectMany(x => x.Value).All(x => x.Status == DomainEventStatus.Completed || x.Status == DomainEventStatus.Failed);
    
    public EventTrackerCollection()
    {
        _events = new();
    }

    public void AddEventTracker<TEvent>(bool requiredForCompletion, int amountToTrack = 1) where TEvent : IDomainEvent
    {
        if (!_events.TryGetValue(typeof(TEvent), out _)) 
        {
            var collection = new EventTracker[amountToTrack];
            for(int i = 0; i < amountToTrack; i++)
            {
                collection[i] = new(requiredForCompletion);
            }
            _events[typeof(TEvent)] = collection;
        }
        //_evnets.TryAdd(typeof(TEvent), new(requiredForCompletion));
    }

    public void RemoveEvent<TEvent>()
    {
        var e = _events[typeof(TEvent)].First(x => x.Status == DomainEventStatus.Awaiting);
        if (e is not null) 
        {
            _events.Remove(typeof(TEvent));
        }
    }

    public void UpdateEvent<TEvent>(DomainEventStatus status) where TEvent : IDomainEvent
    {
        if (!_events.ContainsKey(typeof(TEvent)))
        {
            //throw new Exception("Incorrect key.");
        }
        var e = _events[typeof(TEvent)].First(x => x.Status == DomainEventStatus.Awaiting);
        e?.UpdateStatus(status);
    }
}