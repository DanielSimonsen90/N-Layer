using Microsoft.EntityFrameworkCore;

namespace Project.Core
{
    /// <summary>
    /// UnitOfWork should extend this class
    /// </summary>
    public abstract class BaseUnitOfWork<TDbContext> : IBaseUnitOfWork, IDisposable
        where TDbContext : DbContext
    {
        /// <param name="context">ApplicationDbContext</param>
        public BaseUnitOfWork(TDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// DbContext
        /// </summary>
        protected TDbContext Context { get; }

        /// <inheritdoc/>
        public Task<int> SaveChangesAsync() => Context.SaveChangesAsync();

        /// <summary>
        /// Dispose DbContext
        /// </summary>
        void IDisposable.Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
