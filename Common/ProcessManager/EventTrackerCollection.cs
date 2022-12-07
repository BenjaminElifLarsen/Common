using Common.Events.Domain;
using System;
namespace Common.ProcessManager;
/// <summary>
/// Used by process managers to know which events are requried or not and what the state of them are.
/// </summary>
public sealed class EventTrackerCollection //consider better name and move
{
    protected Dictionary<Type, IEnumerable<EventTracker>> _evnets;

    public bool Failed => _evnets.SelectMany(x => x.Value).Any(x => x.Status == DomainEventStatus.Failed);
    public bool AllRequiredSucceded => _evnets.SelectMany(x => x.Value).Where(x => x.Required == true).All(x => x.Status == DomainEventStatus.Completed);
    public bool AllFinishedOrFailed => _evnets.SelectMany(x => x.Value).All(x => x.Status == DomainEventStatus.Completed || x.Status == DomainEventStatus.Failed);
    
    public EventTrackerCollection()
    {
        _evnets = new();
    }

    public void AddEventTracker<TEvent>(bool requiredForCompletion, int amountToTrack = 1) where TEvent : IDomainEvent
    {
        if (!_evnets.TryGetValue(typeof(TEvent), out _)) 
        {
            var collection = new EventTracker[amountToTrack];
            for(int i = 0; i < amountToTrack; i++)
            {
                collection[i] = new(requiredForCompletion);
            }
            _evnets[typeof(TEvent)] = collection;
        }
        //_evnets.TryAdd(typeof(TEvent), new(requiredForCompletion));
    }

    public void RemoveEvent<TEvent>()
    {
        var e = _evnets[typeof(TEvent)].First(x => x.Status == DomainEventStatus.Awaiting);
        if (e is not null) 
        {
            _evnets.Remove(typeof(TEvent));
        }
    }

    public void UpdateEvent<TEvent>(DomainEventStatus status) where TEvent : IDomainEvent
    {
        if (!_evnets.ContainsKey(typeof(TEvent)))
        {
            //throw new Exception("Incorrect key.");
        }
        var e = _evnets[typeof(TEvent)].First(x => x.Status == DomainEventStatus.Awaiting);
        e?.UpdateStatus(status);
    }
}