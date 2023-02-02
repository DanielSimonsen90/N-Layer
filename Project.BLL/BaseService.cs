using Project.DAL;
using Project.Core;
using Project.DAL.Entities;
using Repository;

namespace Project.BLL
{
    public abstract class BaseService
    {
        protected readonly UnitOfWork unitOfWork = new();
        public static bool IsUserInDepartment(User user, Department department)
        {
            return user.DepartmentId == department.Id;
        }

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

        protected void UpdateUserAndDepartment(User user, Department department)
        {
            unitOfWork.Users.Update(user);
            unitOfWork.Departments.Update(department);
        }
    }
}
