using System.Linq.Expressions;
using Project.Core;

namespace Repository
{
    public partial interface IBaseRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
    {
        bool Add(TEntity entity);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity? Get(TId id);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetWithRelations(TId id, params Expression<Func<TEntity, object?>>[] relations);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);
        bool Delete(TId id);
    }
}
