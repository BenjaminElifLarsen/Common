namespace Common.Events.Store;
public class Aggregate
{
    public int AggregateId { get; private set; }
    public string Type { get; private set; }
    public int Version { get; private set; }
}
