using Project.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Entities.DTO
{
    /// <summary>
    /// DTO object for <see cref="Department"/>.
    /// This extends <see cref="BaseEntity{string}"/> to also be used as a base class for <see cref="Department"/>.
    /// </summary>
    public class DepartmentDTO : BaseEntity<string>
    {
        /// <summary>.
        /// Convert <see cref="Department"/> to <see cref="DepartmentDTO"/>
        /// </summary>
        /// <param name="department">Department to convert to DTO.</param>
        /// <returns>DTO object of <paramref name="department"/>.</returns>
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

        /// <summary>
        /// Name of the department.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Id of the boss of the department.
        /// </summary>
        public int BossId { get; set; }

        /// <summary>
        /// Collection of employee user ids.
        /// </summary>
        [NotMapped]
        public ICollection<int> EmployeeIds { get; set; } = new HashSet<int>();
    }
}
