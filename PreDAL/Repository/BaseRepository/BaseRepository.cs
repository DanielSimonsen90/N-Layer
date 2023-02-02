using Microsoft.EntityFrameworkCore;
using Repository;
using System.Linq.Expressions;

namespace Project.Core
{
    public abstract partial class BaseRepository<TEntity, TId, TDbContext> : IBaseRepository<TEntity, TId> 
        where TEntity : BaseEntity<TId>
        where TDbContext : DbContext
    {
        public BaseRepository(TDbContext context)
        {
            _context = context;
        }

        protected readonly TDbContext _context;
        protected abstract DbSet<TEntity> Set { get; }

        public bool Exists(TId id) => Get(id) is not null;
        public bool Exists(TEntity entity) => Get(entity.Id) is not null;
    }
}