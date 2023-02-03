using Project.DAL;
using Project.Core;
using Project.DAL.Entities;
using Repository;

namespace Project.BLL
{
    /// <summary>
    /// Base service for all services.
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// Check if <paramref name="user"/> is in <paramref name="department"/>.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to check.</param>
        /// <param name="department">The <see cref="Department"/> to check.</param>
        /// <returns>True if <paramref name="user"/> is in <paramref name="department"/>.</returns>
        public static bool IsUserInDepartment(User user, Department department) => user.DepartmentId == department.Id;

        /// <summary>
        /// Protected Unit of Work. Protected so child services can use it.
        /// </summary>
        protected readonly UnitOfWork unitOfWork;
        
        public BaseService(ProjectDbContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        /// <summary>
        /// Check if <paramref name="user"/> and <paramref name="department"/> are provided and in database.
        /// This method is only used to throw exceptions.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to check.</param>
        /// <param name="department">The <see cref="Department"/> to check.</param>
        /// <exception cref="ArgumentNullException">If any argument is null</exception>
        /// <exception cref="EntityNotFoundException{User, int}">If user does not exist</exception>
        /// <exception cref="EntityNotFoundException{Department, string}">If department does not exist</exception>
        protected void CheckExists(User user, Department department)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            if (department is null) throw new ArgumentNullException(nameof(department));

            if (!unitOfWork.Users.Exists(user)) throw new EntityNotFoundException<User, int>(nameof(user), user);
            if (!unitOfWork.Departments.Exists(department)) throw new EntityNotFoundException<Department, string>(nameof(department), department);
        }

        /// <summary>
        /// Saves if <paramref name="save"/> is true
        /// </summary>
        /// <param name="save">Should UOW save changes?</param>
        protected async Task HandleSave(bool save)
        {
            if (save) await unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Uses <see cref="UnitOfWork"/> to state <paramref name="user"/> and <paramref name="department"/> as changed
        /// </summary>
        /// <param name="user">The user to update</param>
        /// <param name="department">The department to update</param>
        protected void UpdateUserAndDepartment(User user, Department department)
        {
            unitOfWork.Users.Update(user);
            unitOfWork.Departments.Update(department);
        }
    }
}
