using Project.DAL.Entities.DTO;
using System.Data;

namespace Project.DAL.Entities
{
    public class Department : DepartmentDTO
    {
#nullable disable
        public Department() {}
#nullable enable
        
        public Department(string name, User boss, ICollection<User> employees) 
            : base(name, boss, employees)
        {
            Boss = boss;
            Employees = employees;
        }
        public override string Id { get; set; } = Guid.NewGuid().ToString();
        public User Boss { get; set; }
        public ICollection<User> Employees { get; set; } = new HashSet<User>();

        public bool HasEmployee(User user) => EmployeeIds.Contains(user.Id);
    }
}
