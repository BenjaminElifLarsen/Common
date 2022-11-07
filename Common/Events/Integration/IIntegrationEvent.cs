namespace Common.Events.Integration;
public interface IIntegrationEvent<TSourceData>
{
    public string AggregateType { get; }
    public int AggregateId { get; }
    public string EventType { get; }
    public Guid EventId { get; } //these events should be stored in a context and this is the id. Not sure if domain events would benefit from being stored.
    /// <summary>
    /// When the event was recorded.
    /// </summary>
    public long TimeStampRecorded { get; }
    /// <summary>
    /// Used by event bus. As long time it is 'AwatingPublishing' is should try to publish (maybe have a delay).
    /// When the event bus has successful published, it should trigger a new transaction in the source service that moves the sate to 'Published'
    /// </summary>
    public IntegrationStatuses Status { get; }
    /// <summary>
    /// The source data, that is the changes/added/deleted/etc. that was done. 
    /// </summary>
    public TSourceData Data { get; }
}
