using Common.Events.Base;
using Common.Events.Domain;
using System.Diagnostics;

namespace Common.ProcessManager;
/// <summary>
/// Used by process managers to know which events are requried or not and what the state of them are.
/// </summary>
public sealed class EventStateCollection //consider better name and move
{ //come up with a better state system for process managers
    private Dictionary<Type, IEnumerable<EventState>> _events;

    //need to update these 
    public bool Failed => _events.SelectMany(x => x.Value).Where(x => x.Type == DomainEventType.Succeeder).Any(x => x.Status == DomainEventStatus.Failed);
    public bool AllRequiredSucceded => _events.SelectMany(x => x.Value).Where(x => x.Required == true && x.Type == DomainEventType.Succeeder).Where(x => x.Status != DomainEventStatus.Removed).All(x => x.Status == DomainEventStatus.Completed);
    public bool AllFinishedOrFailed => _events.SelectMany(x => x.Value).All(x => x.Status == DomainEventStatus.Completed || x.Status == DomainEventStatus.Failed || x.Status == DomainEventStatus.Removed);
    
    public EventStateCollection()
    {
        _events = new();
    }
    /*
     * events are either required or not required.
     * events also either of type failer or type succeeder
     * event of type succeeder can either be required or not requred,
     * event of type failer should never be required
     * so the pm is done when all required events are done.
     * pm has succeeded when all required of type suceeder is complete and not a single type failer is complete
     * maybe have a new event status of 'NotNeeded' or 'NotLongerNeeded' or something like that.
     * meant to be used with both required and not required events
     * 
     * let there be two events, A a required succeeder and B a non-required failer, that can be caused by the same command, what should happen when:
     *  the pm receives an event of type B
     *      The eventState of B is sat to completed
     *      Should eventState of A's status be sat to be Failed or Removed? Removed might make most sense
     *      
     *  the pm receives an event of tpye A
     *      The eventState of A is sat to complete
     *      eventState of B is sat to Removed
     *      
     * when calling RemoveEventTracker<TEvent> should it remove an event state from the collection or set it to NoLongerNeeded?
     *  
     * Instead of letting people directly set the status let it all be done via different methods, one for each status. 
     *  this also permit preventing people overwitting specific statuses.
     *  so remove updateEventTracker
     */
    public void AddEventTracker<TEvent>(bool requiredForCompletion, DomainEventType type, int amountToTrack = 1) where TEvent : IBaseEvent
    {
        if (!_events.TryGetValue(typeof(TEvent), out _)) 
        {
            var collection = new EventState[amountToTrack];
            for(int i = 0; i < amountToTrack; i++)
            {
                collection[i] = new(requiredForCompletion, type);
                #if DEBUG
                Debug.WriteLine($"Added {typeof(TEvent).Name}");
                #endif
            }
            _events[typeof(TEvent)] = collection;
        }
        else
        {
            var collection = _events[typeof(TEvent)].ToList();
            for(int i = 0; i < amountToTrack; i++)
            {
                collection.Add(new(requiredForCompletion, type));
                #if DEBUG
                Debug.WriteLine($"Added {typeof(TEvent).Name}");
                #endif
            }
            _events[typeof(TEvent)] = collection;
        }
    }

    public bool? HasEventCompleted<TEvent>() where TEvent : IBaseEvent
    {
        if (!_events.ContainsKey(typeof(TEvent)))
        {
            return null;
        }
        return _events[typeof(TEvent)].All(x => x.Status == DomainEventStatus.Completed);
    }

    public bool? HasEventFailed<TEvent>() where TEvent : IBaseEvent
    {
        if (!_events.ContainsKey(typeof(TEvent)))
        {
            return null;
        }
        return _events[typeof(TEvent)].All(x => x.Status == DomainEventStatus.Failed);
    }

    public void RemoveEvent<TEvent>() where TEvent : IBaseEvent
    {
        var e = _events[typeof(TEvent)].FirstOrDefault(x => x.Status == DomainEventStatus.Awaiting);
        if (e is not null) 
        {
            if (e.Required)
            {
                throw new Exception("Cannot remove a required event. Call FailEvent on it instead.");
            }
            e.UpdateStatus(DomainEventStatus.Removed);
            #if DEBUG
            Debug.WriteLine($"Removed {typeof(TEvent).Name}");
            #endif
        }
    }

    public void CompleteEvent<TEvent>() where TEvent : IBaseEvent
    {
        var e = _events[typeof(TEvent)].FirstOrDefault(x => x.Status == DomainEventStatus.Awaiting);
        if (e is not null)
        {
            e.UpdateStatus(DomainEventStatus.Completed);
            #if DEBUG
            Debug.WriteLine($"Completed {typeof(TEvent).Name}");
            #endif
        }
    }

    public void FailEvent<TEvent>() where TEvent : IBaseEvent
    {
        var e = _events[typeof(TEvent)].FirstOrDefault(x => x.Status == DomainEventStatus.Awaiting);
        if (e is not null)
        {
            e.UpdateStatus(DomainEventStatus.Failed);
            #if DEBUG
            Debug.WriteLine($"Failed {typeof(TEvent).Name}");
            #endif
        }
    }
}