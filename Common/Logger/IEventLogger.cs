using Common.Events.Base;

namespace Common.Logger;
public interface IEventLogger
{
    public void Handle(IBaseEvent @event);
}
