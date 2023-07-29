using Common.Events.Base;
using System.Diagnostics;

namespace Common.Logger;
public class TestingEventLogger : IEventLogger
{
    public void Handle(IBaseEvent @event)
    {
        Debug.WriteLine($"{@event.CorrelationId} : {@event.CausationId} : {@event.EventId} : {@event.GetType()}");
    }
}
