namespace Common.ProcessManager;

public sealed class EventTracker //consider better name
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
/*
 * consider other ways to deal with this problem
 * another way around this problem could be to give EventTracker an id as each id already contains an EventId
 * e.g. an event is triggered which will create a command that modify 15 aggregates. The tracker then knows it need to keep track of 15 of a specific event
 * each time it get one of those 15 events (15 of fails and sucesses) it will record the id into the EventTracker, so it knows not to response to any of the same event (same as in both failer and success) with that EventId.
 * will not work, each event id will be different.
 * maybe have a single event (instead of tracking 15 failers and successes) that states which failed, e.g. which operators was not found and needs to be removed from license type.
 * while also containing the ids of those which no longer are valid.
 */
public sealed class MultiEventTracker
{
    private int _amountCompleted;
    public bool Required { get; private set; }
    public DomainEventStatus Status { get; private set; }
    public int Amount { get; private set; }

    public MultiEventTracker(bool required, int amount)
    {
        _amountCompleted = 0;
        Required = required;
        Status = DomainEventStatus.Awaiting;
        Amount = amount;
    }

    public void UpdateStatus(DomainEventStatus status)
    { //how to handle if some events return failed, but not others?
        if(status == DomainEventStatus.Completed && _amountCompleted != Amount && status != DomainEventStatus.Failed)
        {
            AnEventFinished();
        }
        else if (status == DomainEventStatus.Failed)
        {
            Status = status;
        }
        else 
        {
            if(Status != DomainEventStatus.Failed)
            {
                Status = status;
            }
        }
    }

    private void AnEventFinished()
    {
        if (_amountCompleted != Amount) 
        {
            _amountCompleted++;
            if (Status != DomainEventStatus.InProgress)
            {
                Status = DomainEventStatus.InProgress;
            }
        }
        else if (Status != DomainEventStatus.Completed && Status != DomainEventStatus.Failed)
        {
            Status = DomainEventStatus.Completed;
        }
    }
}