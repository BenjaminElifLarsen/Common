using Common.Events.Domain;

namespace Common.Events.Projection;
public interface IViewQuery<T, TId> where T : IProjection
{
    public T? Projection(IEnumerable<DomainEvent<TId>> events);
}

public interface IViewQuery<T> where T : IProjection
{
    public T? Projection(IEnumerable<DomainEvent> events);
}
