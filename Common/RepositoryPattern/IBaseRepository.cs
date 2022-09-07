using Common.Aggregate;
using Common.CQRS.Queries;
using System.Linq.Expressions;

namespace Common.DataHandling;
public interface IBaseRepository<TEntity> where TEntity : class, IAggregateRoot
{
    public Task Create(TEntity entity);
    public Task Update(TEntity entity);
    public Task Delete(TEntity entity);
    public Task<IEnumerable<TProjection>> AllAsync<TProjection>(BaseQuery<TEntity, TProjection> query) where TProjection : BaseReadModel;
    public Task<IEnumerable<TProjection>> AllByPredicateAsync<TProjection>(Expression<Func<TEntity, bool>> predicate, BaseQuery<TEntity, TProjection> query) where TProjection : BaseReadModel;
    public Task<TProjection> FindByPredicateAsync<TProjection>(Expression<Func<TEntity, bool>> predicate, BaseQuery<TEntity, TProjection> query) where TProjection : BaseReadModel;
    public Task SaveChanges();
    //have a save function void Save()
}
