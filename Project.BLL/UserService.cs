using Project.DAL;
using Project.DAL.Entities;

namespace Project.BLL
{
    public class UserService : BaseService
    {
        public UserService(ProjectDbContext context) : base(context) {}

        public async Task Hire(User user, Department department, bool save = false)
        {
            CheckExists(user, department);

            if (IsUserInDepartment(user, department)) throw new UserAlreadyInDepartmentException(user, department);

            SetDepartmentFor(ref user, ref department);

            UpdateUserAndDepartment(user, department);

            await HandleSave(save);
        }

        /// <summary>
        /// Move <paramref name="user"/> to <paramref name="department"/>.
        /// </summary>
        /// <param name="user">User/Employee to move</param>
        /// <param name="department">Department to move to</param>
        /// <param name="save">Save move opreation</param>
        public async Task Move(User user, Department department, bool save = false)
        {
            CheckExists(user, department);

            if (IsUserInDepartment(user, department)) throw new UserAlreadyInDepartmentException(user, department);

            SetDepartmentFor(ref user, ref department);

            UpdateUserAndDepartment(user, department);

            await HandleSave(save);
        }

        public async Task Fire(User user, bool save = false)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            if (user.Department is not Department department) return;

            department.Employees.Remove(user);
            department.EmployeeIds.Remove(user.Id);
            unitOfWork.Departments.Update(department);

            await HandleSave(save);
        }

        protected static void SetDepartmentFor(ref User user, ref Department department)
        {
            user.Department = department;
            user.DepartmentId = department?.Id;
            
            if (department is null) return;
            
            department.Employees.Add(user);
            //department.EmployeeIds.Add(user.Id);
        }
    }
}
