using Project.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Entities.DTO
{
    public class DepartmentDTO : BaseEntity<string>
    {
        public static DepartmentDTO Convert(Department department)
        {
            return new DepartmentDTO(department.Name, department.Boss, department.Employees);
        }

#nullable disable
        public DepartmentDTO() {}
#nullable enable
        
        public DepartmentDTO(string name, User boss, ICollection<User> employees)
        {
            Name = name;
            BossId = boss.Id;
            EmployeeIds = employees.Select(e => e.Id).ToList();
        }
        public string Name { get; set; }
        public int BossId { get; set; }

        [NotMapped]
        public ICollection<int> EmployeeIds { get; set; } = new HashSet<int>();
    }
}
