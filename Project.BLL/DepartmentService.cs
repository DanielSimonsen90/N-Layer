using Project.DAL;
using Project.DAL.Entities;

namespace Project.BLL
{
    public class DepartmentService : BaseService
    {
        public DepartmentService(ProjectDbContext context, UserService userService) : base(context)
        {
            _userService = userService;
        }

        private readonly UserService _userService;

        public async Task Promote(User user, Department department, bool save = false)
        {
            CheckExists(user, department);

            if (!IsUserInDepartment(user, department))
            {
                await _userService.Move(user, department);
            }

            User? currentBoss = unitOfWork.Users.Get(department.BossId);
            if (currentBoss is not null)
            {
                await _userService.Move(currentBoss, department);
            }

            department.Boss = user;
            department.BossId = user.Id;
            unitOfWork.Departments.Update(department);

            user.Department = null;
            user.DepartmentId = null;
            unitOfWork.Users.Update(user);

            await HandleSave(save);
        }

        public Department? GetDepartmentWhereUserIsBoss(User user) => unitOfWork.Departments
            .Get(department => department.BossId == user.Id);
        public IEnumerable<Department> GetDepartmetsExcludeUsersDepartment(User user) => unitOfWork.Departments
            .GetAll(Department => Department.Id != user.DepartmentId);
    }
}