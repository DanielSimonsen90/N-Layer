using Microsoft.EntityFrameworkCore;
using Repository;
using System.Linq.Expressions;

namespace Project.Core
{
    public abstract partial class BaseRepository<TEntity, TId, TDbContext> : IBaseRepository<TEntity, TId>
    {
        /// <inheritdoc/>
        public virtual bool Add(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            Set.Add(entity);

            return true;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TEntity> GetAll() => Set.ToList() ?? new List<TEntity>();
        /// <inheritdoc/>
        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate) => Set.Where(predicate).ToList();

        /// <inheritdoc/>
        public virtual TEntity? Get(TId id)
        {
            bool invalidNumber = id is int numId && numId < 0;
            bool invalidString = id is string stringId && string.IsNullOrEmpty(stringId);

            if (invalidNumber || invalidString) throw new ArgumentNullException(nameof(id));

            return Set.Find(id);
        }
        
        /// <inheritdoc/>
        public virtual TEntity? Get(Expression<Func<TEntity, bool>> predicate) => Set.FirstOrDefault(predicate);
        /// <inheritdoc/>
        public virtual TEntity? GetWithRelations(TId id, params Expression<Func<TEntity, object?>>[] relations)
        {
            IQueryable<TEntity> query = Set;

            foreach (var relation in relations)
            {
                query = query.Include(relation);
            }

            return query.FirstOrDefault(e => e.Id!.Equals(id));
        }

        /// <inheritdoc/>
        public virtual bool Update(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            TEntity? existing = Get(entity.Id);
            if (existing is null) throw new EntityNotFoundException<TEntity, TId>(nameof(existing), existing);

            _context.Entry(existing).CurrentValues.SetValues(entity);
            return true;
        }

        /// <inheritdoc/>
        public virtual bool Delete(TId id)
        {
            TEntity? existing = Get(id);
            if (existing is null) throw new EntityNotFoundException<TEntity, TId>(nameof(existing), existing);

            return Delete(existing);
        }
        /// <inheritdoc/>
        public virtual bool Delete(TEntity entity)
        {
            if (entity is null) throw new EntityNotFoundException<TEntity, TId>(nameof(entity), entity);

            Set.Remove(entity);
            return true;
        }
    }
}
