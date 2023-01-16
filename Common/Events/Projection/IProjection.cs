using Common.Events.Domain;

namespace Common.Events.Projection;

public interface ISingleProjection<T>
{
    public abstract static T SingleProjection(IEnumerable<DomainEvent> events);
}

public interface IMultiProjection<T>
{
    public abstract static IEnumerable<T> MultiProjection(IEnumerable<DomainEvent> events);
}