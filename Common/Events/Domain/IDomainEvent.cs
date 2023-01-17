using Common.Events.Base;

namespace Common.Events.Domain;

public interface IDomainEvent<T> : IBaseEvent
{
    public string AggregateType { get; }
    public T AggregateId { get; }
    public int Version { get; }
}