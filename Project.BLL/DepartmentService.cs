using Project.DAL;
using Project.DAL.Entities;

namespace Project.BLL
{
    /// <summary>
    /// Service for <see cref="Department"/>s.
    /// </summary>
    public class DepartmentService : BaseService
    {
        public DepartmentService(ProjectDbContext context, UserService userService) : base(context)
        {
            _userService = userService;
        }

        private readonly UserService _userService;

        /// <summary>
        /// Promote <paramref name="user"/> to boss in <paramref name="department"/>.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to promote.</param>
        /// <param name="department">The <see cref="Department"/> that gets <paramref name="user"/> as boss.</param>
        /// <param name="save">Save changes after run. Default is false.</param>
        public async Task Promote(User user, Department department, bool save = false)
        {
            // Check if user and department are valid objects. Throws exceptions if not.
            CheckExists(user, department);

            // Get the current boss of the department
            User? currentBoss = unitOfWork.Users.Get(department.BossId);
            if (currentBoss is not null)
            {
                // Move currentBoss to the department, so they get "demoted" to employee of the department
                await _userService.Move(currentBoss, department);
            }

            // Set boss reference to user and mark department as updated
            department.Boss = user;
            department.BossId = user.Id;
            unitOfWork.Departments.Update(department);

            // Remove department references, as user.OwnedDepartment is used instead, then mark user as updated.
            user.Department = null;
            user.DepartmentId = null;
            unitOfWork.Users.Update(user);

            // Save if save argument is true
            await HandleSave(save);
        }

        /// <summary>
        /// Get departments where <paramref name="user"/> is the boss.
        /// </summary>
        /// <param name="user">The user to get the department from</param>
        /// <returns>The department the user is boss of.</returns>
        public Department? GetDepartmentWhereUserIsBoss(User user) => unitOfWork.Departments
            .Get(department => department.BossId == user.Id);

        /// <summary>
        /// Get departments without the department the <paramref name="user"/> is in
        /// </summary>
        /// <param name="user">The user to use to find their department</param>
        /// <returns>All departments except for <param name="user"/>'s <see cref="User.Department"/></returns>
        public IEnumerable<Department> GetDepartmetsExcludeUsersDepartment(User user) => unitOfWork.Departments
            .GetAll(Department => Department.Id != user.DepartmentId);
    }
}