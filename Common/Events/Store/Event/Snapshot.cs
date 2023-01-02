namespace Common.Events.Store.Event;
public class Snapshot
{ //consider making an interface with the properties, but a generic aggregateId. Same for event and aggregate model
    public int AggregateId { get; private set; }
    public string SerialisedData { get; private set; }
    public int Version { get; private set; }
}
