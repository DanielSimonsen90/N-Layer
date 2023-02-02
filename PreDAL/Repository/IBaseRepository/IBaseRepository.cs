using Project.Core;

namespace Repository
{
    public partial interface IBaseRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
    {
        bool Exists(TId id);
        bool Exists(TEntity entity);
    }
}
