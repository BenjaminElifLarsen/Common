using Common.Events.Domain;

namespace Common.Events.Projection;
public interface IViewSingleQuery<T, TId> where T : ISingleProjection<T>
{
    public T? SingleProjection(IEnumerable<DomainEvent<TId>> events);
}

public interface IViewSingleQuery<T> where T : ISingleProjection<T>
{
    public T? SingleProjection(IEnumerable<DomainEvent> events);
}

public interface IViewMultiQuery<T> where T : IMultiProjection<T>
{
    public IEnumerable<T> MultiProjection(IEnumerable<DomainEvent> events);
}
