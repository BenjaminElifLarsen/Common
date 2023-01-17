using Common.Events.Base;

namespace Common.ProcessManager;
public interface IProcessManagerEventHandler<TEvent> where TEvent : IBaseEvent
{ //old design
    void Handle(TEvent @event);
}
