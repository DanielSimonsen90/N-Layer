using System.Linq.Expressions;
using Project.Core;

namespace Repository
{
    /// <summary>
    /// Interface used to implement features in <see cref="BaseRepository{TEntity, TId, TDbContext}"/>.
    /// </summary>
    /// <typeparam name="TEntity">Generic entity for repository</typeparam>
    /// <typeparam name="TId">Generic id type for entity</typeparam>
    public partial interface IBaseRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
    {
        /// <summary>
        /// Add <typeparamref name="TEntity"/> to database.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <returns>True if sucessful.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="entity"/> is null</exception>
        bool Add(TEntity entity);

        /// <summary>
        /// Get all entities from database.
        /// </summary>
        /// <returns>Collection of entities found.</returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Get all entities from database, filtered by <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">Filter entities by boolean. If true, include <typeparamref name="TEntity"/> in collection.</param>
        /// <returns>Collection of entities found and filtered.</returns>
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get an <typeparamref name="TEntity"/> by id.
        /// </summary>
        /// <param name="id">Id of the <typeparamref name="TEntity"/>.</param>
        /// <returns><typeparamref name="TEntity"/> if entity with <paramref name="id"/> was found.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="entity"/> is null</exception>
        TEntity? Get(TId id);
        /// <summary>
        /// Get an <typeparamref name="TEntity"/> filtered by <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">Get <typeparamref name="TEntity"/> by boolean. If true, return <typeparamref name="TEntity"/>.</param>
        /// <returns>Entity found by <paramref name="predicate"/>, if any found.</returns>
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Get entity by <paramref name="id"/>, including relations mapped through <paramref name="relations"/>.
        /// </summary>
        /// <param name="id">Id of the <typeparamref name="TEntity"/> to get.</param>
        /// <param name="relations">Relations to include from entity. Relations being non-primitive types from entity model.</param>
        /// <returns>Entity with relations.</returns>
        TEntity? GetWithRelations(TId id, params Expression<Func<TEntity, object?>>[] relations);

        /// <summary>
        /// Update <paramref name="entity"/> in database
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> to update.</param>
        /// <returns>If update succeeded.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="entity"/> is null.</exception>
        /// <exception cref="EntityNotFoundException{TEntity, TId}">Thrown if <paramref name="entity"/> was not found in database.</exception>
        bool Update(TEntity entity);

        /// <summary>
        /// Delete <paramref name="entity"/> from database
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> to delete.</param>
        /// <returns>True if deleted.</returns>
        /// <exception cref="EntityNotFoundException{TEntity, TId}">Thrown if <paramref name="entity"/> was not found in database.</exception>
        bool Delete(TEntity entity);
        /// <summary>
        /// Delete entity matching <paramref name="id"/> from database.
        /// </summary>
        /// <param name="id">If of the <typeparamref name="TEntity"/> to delete.</param>
        /// <returns>True if deleted.</returns>
        /// <exception cref="EntityNotFoundException{TEntity, TId}">Thrown if <paramref name="entity"/> was not found in database.</exception>
        bool Delete(TId id);
    }
}
