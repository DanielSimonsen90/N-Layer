namespace Project.Core
{
    public interface IBaseUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
