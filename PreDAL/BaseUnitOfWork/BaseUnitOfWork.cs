using Microsoft.EntityFrameworkCore;

namespace Project.Core
{
    public abstract class BaseUnitOfWork<TDbContext> : IBaseUnitOfWork, IDisposable
        where TDbContext : DbContext
    {
        public BaseUnitOfWork(TDbContext context)
        {
            Context = context;
        }

        protected TDbContext Context { get; }
        public Task<int> SaveChangesAsync() => Context.SaveChangesAsync();

        void IDisposable.Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
