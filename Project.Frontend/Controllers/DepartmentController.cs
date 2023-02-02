using Microsoft.AspNetCore.Mvc;

namespace Project.Frontend.Controllers
{
    public class DepartmentController : Controller
    {
        public UnitOfWork UnitOfWork { get; }
        public UserService UserService { get; }
        public DepartmentService DepartmentService { get; }

        public DepartmentController(UnitOfWork unitOfWork, UserService userService, DepartmentService departmentService)
        {
            UnitOfWork = unitOfWork;
            UserService = userService;
            DepartmentService = departmentService;
        }
        public async Task<IActionResult> Hire(int userId, string departmentId)
        {
            User? user = UnitOfWork.Users.Get(userId);
            Department? department = UnitOfWork.Departments.Get(departmentId);

            if (user is not null && department is not null) 
                await UserService.Hire(user, department, true);

            return RedirectToAction("Index", "Home");
        }
        
        public async Task<IActionResult> Create(Department department)
        {
            UnitOfWork.Departments.Add(department);
            await UnitOfWork.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(string departmentId)
        {
            UnitOfWork.Departments.Delete(departmentId);
            await UnitOfWork.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }
    }
}
