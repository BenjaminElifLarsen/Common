namespace Common.Events.Domain;

public interface IDomainEvent
{
    public string AggregateType { get; }
    public int AggregateId { get; }
    public string EventType { get; }
    public Guid EventId { get; }
    /// <summary>
    /// When the event was recorded.
    /// </summary>
    public long TimeStampRecorded { get; }
    public Guid CorrelationId { get; }
    public Guid CausationId { get; }
    /// <summary>
    /// Unique and sequential for a given aggregate root.
    /// </summary>
    public int Version { get; }
}

public interface IDomainEvent<TData> : IDomainEvent
{ 
    /// <summary>
    /// The source data, that is the changes/added/deleted/etc. that was done. 
    /// </summary>
    public TData Data { get; } //if needed to be stored in a context, could store the data in a json string
}

public interface IDomainEventFail : IDomainEvent
{
    /// <summary>
    /// Errros messages.
    /// </summary>
    public IEnumerable<string> Errors { get; }
}

public interface IDomainEvnetSuccess : IDomainEvent
{ //just an extension of IDomainEvent to have a 'counter' of the Failed version.

}

public interface IDomainEventSuccess<TData> : IDomainEvent<TData>
{ //just an extension of IDomainEvent to have a 'counter' of the Failed version.

}