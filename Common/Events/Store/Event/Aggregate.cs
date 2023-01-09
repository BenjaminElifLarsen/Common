using Common.RepositoryPattern;

namespace Common.Events.Store.Event;
public class Aggregate<T>
{
    public T AggregateId { get; private set; }
    public string Type { get; private set; }
    public int Version { get; private set; }

    private Aggregate()
    {

    }

    public Aggregate(IAggregateRoot<T> aggregate)
    {
        AggregateId = aggregate.Id;
        Type = aggregate.GetType().Name;
        Version = -1;
    }

    public Aggregate(T aggregateId, string type)
    {
        AggregateId = aggregateId;
        Type = type;
        Version = -1;
    }

    public void UpdateVersion(int version)
    {
        Version = version;
    }
}

public class Aggregate : Aggregate<Guid>
{
    public Aggregate(IAggregateRoot aggregate) : base(aggregate)
    {

    }

    public Aggregate(Guid aggregateId, string type) : base(aggregateId, type)
    {
    }
}
