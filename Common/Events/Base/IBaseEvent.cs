namespace Common.Events.Base;
public interface IBaseEvent
{
    public string EventType { get; }
    public Guid EventId { get; }
    public long TimeStampRecorded { get; }
    public Guid CorrelationId { get; }
    public Guid CausationId { get; }
}
