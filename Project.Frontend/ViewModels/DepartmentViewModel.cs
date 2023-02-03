namespace Project.Frontend.ViewModels
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel(IEnumerable<Department> departments)
        {
            Departments = departments;
        }

        public IEnumerable<Department> Departments { get; set; }
        public Department Shell { get; set; } = new();
        public string EmployeesCount(Department department) => $"{department.Employees.Count()} employee{(department.Employees.Count() > 1 ? "s" : "")}";
    }
}