using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Project.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public HomeController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var userModel = new UserViewModel(unitOfWork.Users.GetAll());
            var departmentModel = new DepartmentViewModel(unitOfWork.Departments.GetAll());

            return View(new HomeViewModel(userModel, departmentModel));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}