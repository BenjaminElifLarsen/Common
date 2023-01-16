using Common.Events.Domain;
namespace Common.Events.Projection;
public static class ProjectionExtension
{
    public static T Projection<T>(this IEnumerable<DomainEvent> events, IViewQuery<T> query) where T : IProjection
    {
        return query.Projection(events);
    }

    public static T Projection<T, TId>(this IEnumerable<DomainEvent<TId>> events, IViewQuery<T, TId> query) where T : IProjection
    {
        return query.Projection(events);
    }
}
