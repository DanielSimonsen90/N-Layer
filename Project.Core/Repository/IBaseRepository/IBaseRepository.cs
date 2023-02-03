using Project.Core;

namespace Repository
{
    public partial interface IBaseRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
    {
        /// <summary>
        /// If database has <typeparamref name="TEntity"/> with id <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if entity with <paramref name="id"/> was found.</returns>
        bool Exists(TId id);

        /// <summary>
        /// If <paramref name="entity"/> exists in database.
        /// </summary>
        /// <param name="entity">Entity to check if exists in database.</param>
        /// <returns>True if entity exists in database</returns>
        bool Exists(TEntity entity);
    }
}
