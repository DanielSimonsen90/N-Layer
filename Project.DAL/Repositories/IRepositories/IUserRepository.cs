using Project.DAL.Entities;

namespace Project.DAL.Repositories.IRepositories
{
    /// <summary>
    /// Interface to force implementation of <see cref="User"/> repository, <see cref="UserRepository"/>.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get a <see cref="User"/> by their username.
        /// </summary>
        /// <param name="username">The username to look for</param>.
        /// <returns>The <see cref="User"/> found, if any.</returns>
        User? GetByUsername(string username);

        /// <summary>
        /// Get all users that are not in <paramref name="department"/>.
        /// </summary>
        /// <param name="department">The department to exclude</param>
        /// <returns>Users that are not in <paramref name="department"/>.</returns>
        IEnumerable<User> GetUsersNotInDepartment(Department department);

        /// <summary>
        /// Get a <see cref="User"/> with their <see cref="Department"/> object included.
        /// </summary>
        /// <param name="id">Id of the <see cref="User"/>.</param>
        /// <returns>The <see cref="User"/> matching <paramref name="id"/> with their <see cref="Department"/>, if any found.</returns>
        User? GetWithDepartment(int id);
    }
}
