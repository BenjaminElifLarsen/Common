﻿namespace Common.Events.Domain;

public interface IDomainEvent
{//pratice and testing, not finalised yet and may not be used in final design'
    //designed out from some reading
    public string AggregateType { get; }
    public int AggregateId { get; }
    public string EventType { get; }
    public Guid EventId { get; }
    /// <summary>
    /// When the event was recorded.
    /// </summary>
    public long TimeStampRecorded { get; }
}

public interface IDomainEvent<TSourceData> : IDomainEvent
{ 
    /// <summary>
    /// The source data, that is the changes/added/deleted/etc. that was done. 
    /// </summary>
    public TSourceData Data { get; } //if needed to be stored in a context, could store the data in a json string
}
