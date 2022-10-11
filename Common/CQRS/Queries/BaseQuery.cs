using System.Linq.Expressions;

namespace Common.CQRS.Queries;
public abstract class BaseQuery<TEntity, TProjection> where TEntity : class where TProjection : BaseReadModel
{
    public abstract Expression<Func<TEntity, TProjection>> Map();
}
