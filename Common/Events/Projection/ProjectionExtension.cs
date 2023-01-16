using Common.Events.Domain;
namespace Common.Events.Projection;
public static class ProjectionExtension
{
    public static T ProjectionSingle<T>(this IEnumerable<DomainEvent> events, IViewSingleQuery<T> query) where T : ISingleProjection<T>
    {
        return query.SingleProjection(events);
    }

    public static T ProjectionSingle<T, TId>(this IEnumerable<DomainEvent<TId>> events, IViewSingleQuery<T, TId> query) where T : ISingleProjection<T>
    {
        return query.SingleProjection(events);
    }

    public static IEnumerable<T> ProjectionMulti<T>(this IEnumerable<DomainEvent> events, IViewMultiQuery<T> query) where T : IMultiProjection<T>
    {
        return query.MultiProjection(events);
    }
}
