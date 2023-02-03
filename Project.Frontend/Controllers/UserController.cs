using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Project.Frontend.Controllers
{
    public class UserController : Controller
    {
        public UnitOfWork UnitOfWork { get; }
        public UserService UserService { get; }
        public DepartmentService DepartmentService { get; }

        public UserController(UnitOfWork unitOfWork, UserService userService, DepartmentService departmentService)
        {
            UnitOfWork = unitOfWork;
            UserService = userService;
            DepartmentService = departmentService;
        }

        public async Task<IActionResult> Move(int userId, string departmentId)
        {
            User? user = UnitOfWork.Users.Get(userId);
            Department? department = UnitOfWork.Departments.Get(departmentId);

            if (user is not null && department is not null) 
                await UserService.Move(user, department, true);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> PromoteToBoss(int userId)
        {
            User? user = UnitOfWork.Users.GetWithDepartment(userId);
            if (user is not null && user.Department is not null) 
                await DepartmentService.Promote(user, user.Department, true);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Fire(int userId)
        {
            User? user = UnitOfWork.Users.GetWithDepartment(userId);
            if (user is not null)
                await UserService.Fire(user, true);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Create(User user)
        {
            UnitOfWork.Users.Add(user);
            await UnitOfWork.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(int userId)
        {
            UnitOfWork.Users.Delete(userId);
            await UnitOfWork.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
