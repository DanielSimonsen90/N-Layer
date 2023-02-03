using Project.DAL;
using Project.DAL.Entities;

namespace Project.BLL
{
    /// <summary>
    /// Service for <see cref="User"/>s.
    /// </summary>
    public class UserService : BaseService
    {
        public UserService(ProjectDbContext context) : base(context) {}

        /// <summary>
        /// Hire <paramref name="user"/> into <paramref name="department"/>.
        /// </summary>
        /// <param name="user">The user to hire into <paramref name="department"/>.</param>
        /// <param name="department">The <see cref="Department"/> to hire <paramref name="user"/> into</param>
        /// <param name="save">Save database after action. Default is false</param>
        /// <exception cref="UserAlreadyInDepartmentException">If <paramref name="user"/> is already hired in <paramref name="department"/>.</exception>
        public async Task Hire(User user, Department department, bool save = false)
        {
            // Check if user and department aren't null and if they exist in database
            CheckExists(user, department);

            // If user.Department is department, throw UserAlreadyInDepartmentException
            if (IsUserInDepartment(user, department)) throw new UserAlreadyInDepartmentException(user, department);

            // Set user's department to department. Ref is used to save the changes in the objects, then used to save
            SetDepartmentFor(ref user, ref department);

            // State user and department as changed
            UpdateUserAndDepartment(user, department);

            // Save if save is true
            await HandleSave(save);
        }

        /// <summary>
        /// Move <paramref name="user"/> to <paramref name="department"/>.
        /// </summary>
        /// <param name="user">User/Employee to move.</param>
        /// <param name="department">Department to move to.</param>
        /// <param name="save">Save move opreation. Default is false</param>
        /// <exception cref="UserAlreadyInDepartmentException">Throws if <paramref name="user"/> is already in <paramref name="department"/>.</exception>
        public async Task Move(User user, Department department, bool save = false)
        {
            // Check if user and department aren't null and if they exist in database
            CheckExists(user, department);

            // If user.Department is department, throw UserAlreadyInDepartmentException
            if (IsUserInDepartment(user, department)) throw new UserAlreadyInDepartmentException(user, department);

            // Set user's department to department. Ref is used to save the changes in the objects, then used to save
            SetDepartmentFor(ref user, ref department);

            // State user and department as changed
            UpdateUserAndDepartment(user, department);

            // Save if save is true
            await HandleSave(save);
        }

        /// <summary>
        /// Fire <paramref name="user"/> from the department they're in.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to fire.</param>
        /// <param name="save">Save the action to database. Default is false.</param>
        /// <exception cref="ArgumentNullException">if <paramref name="user"/> is null.</exception>
        public async Task Fire(User user, bool save = false)
        {
            // Check if user exists and user has a department.
            if (user is null) throw new ArgumentNullException(nameof(user));
            if (user.Department is not Department department) return;

            // Remove user from department's employee properties, then mark as updated.
            department.Employees.Remove(user);
            department.EmployeeIds.Remove(user.Id);
            unitOfWork.Departments.Update(department);

            // Save if save is true
            await HandleSave(save);
        }

        /// <summary>
        /// Set <paramref name="department"/> for <paramref name="user"/>
        /// </summary>
        /// <param name="user">The user to update the <paramref name="department"/> to.</param>
        /// <param name="department">The department to set to <paramref name="user"/>.</param>
        protected static void SetDepartmentFor(ref User user, ref Department department)
        {
            // Set user.Department references
            user.Department = department;
            user.DepartmentId = department?.Id;
            
            // If department is null, ignore employees modification
            if (department is null) return;
            
            // Add user to the department's employee list
            department.Employees.Add(user);
            //department.EmployeeIds.Add(user.Id);
        }
    }
}
