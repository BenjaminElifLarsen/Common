using Common.Events.Base;

namespace Common.ProcessManager;
public interface IProcessManagerEventHandler<TEvent> where TEvent : IBaseEvent
{
    void Handle(TEvent @event);
}
