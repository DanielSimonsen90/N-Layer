using Project.DAL.Entities;

namespace Project.DAL.Repositories.IRepositories
{
    /// <summary>
    /// Interface to force implementation of <see cref="Department"/> repository, <see cref="DepartmentRepository"/>.
    /// </summary>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Get a <see cref="Department"/> by their name.
        /// </summary>
        /// <param name="name">The name to look for</param>.
        /// <returns>The department found.</returns>
        Department? GetByName(string name);

        /// <summary>
        /// Get department by id with the boss reference.
        /// </summary>
        /// <param name="id">The id of the <see cref="Department"/></param>
        /// <returns>The <see cref="Department"/> found with a <see cref="Department.Boss"/> reference.</returns>
        Department? GetWithBoss(string id);
        /// <summary>
        /// Get department by id with the employees reference.
        /// </summary>
        /// <param name="id">The id of the <see cref="Department"/></param>
        /// <returns>The <see cref="Department"/> found with a <see cref="Department.Employees"/> reference.</returns>
        Department? GetWithEmployees(string id);
    }
}
