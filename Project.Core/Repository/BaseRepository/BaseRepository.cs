using Microsoft.EntityFrameworkCore;
using Repository;

namespace Project.Core
{
    /// <summary>
    /// Repositories should extend this class.
    /// </summary>
    /// <typeparam name="TEntity">Generic entity for repository.</typeparam>
    /// <typeparam name="TId">Generic id type, so id can be int, string, guid or other data type.</typeparam>
    /// <typeparam name="TDbContext">Generic DbContext.</typeparam>
    public abstract partial class BaseRepository<TEntity, TId, TDbContext> : IBaseRepository<TEntity, TId> 
        where TEntity : BaseEntity<TId>
        where TDbContext : DbContext
    {
        /// <param name="context">ApplicationDbContext.</param>
        public BaseRepository(TDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// DbContext passed in constructor. This is protected, so Repositories can use this.
        /// </summary>
        protected readonly TDbContext _context;

        /// <summary>
        /// Set of <typeparamref name="TEntity"/>. 
        /// This is used to easily handle CRUD operations without needing to know the exact entity from DbContext.
        /// </summary>
        protected abstract DbSet<TEntity> Set { get; }

        /// <inheritdoc/>
        public bool Exists(TId id) => Get(id) is not null;

        /// <inheritdoc/>
        public bool Exists(TEntity entity) => Get(entity.Id) is not null;
    }
}