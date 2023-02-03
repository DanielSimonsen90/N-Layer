namespace Project.Core
{
    /// <summary>
    /// UnitOfWork implements this through <see cref="BaseUnitOfWork{TDbContext}"/>
    /// </summary>
    public interface IBaseUnitOfWork
    {
        /// <summary>
        /// Save changes to database
        /// </summary>
        /// <returns>Rows affected</returns>
        Task<int> SaveChangesAsync();
    }
}
