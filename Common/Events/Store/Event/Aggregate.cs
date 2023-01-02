using Common.RepositoryPattern;

namespace Common.Events.Store.Event;
public class Aggregate
{
    public int AggregateId { get; private set; }
    public string Type { get; private set; }
    public int Version { get; private set; }

    private Aggregate()
    {

    }

    public Aggregate(IAggregateRoot aggregate)
    {
        AggregateId = aggregate.Id;
        Type = aggregate.GetType().Name;
        Version = 0;
    }
}
