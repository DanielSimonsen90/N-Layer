using Project.DAL.Entities;

namespace Project.BLL
{
    public class DepartmentService : BaseService
    {
        public DepartmentService(UserService userService) : base()
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

            department.Boss = user;
            department.BossId = user.Id;

            unitOfWork.Departments.Update(department);

            await HandleSave(save);
        }

        public Department? GetDepartmentWhereUserIsBoss(User user) => unitOfWork.Departments
            .Get(department => department.BossId == user.Id);
    }
}