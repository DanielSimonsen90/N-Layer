namespace Project.Frontend.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel(UserViewModel users, DepartmentViewModel departments)
        {
            Users = users;
            Departments = departments;
        }

        public UserViewModel Users { get; set; }
        public DepartmentViewModel Departments { get; set; }
    }
}
