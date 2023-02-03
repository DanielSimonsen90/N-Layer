using Project.DAL.Entities.DTO;
using System.Data;

namespace Project.DAL.Entities
{
    /// <summary>
    /// Department entity for this project.
    /// </summary>
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

        /// <summary>
        /// <inheritdoc/>
        /// This is overriden to automatically assign Guid.
        /// </summary>
        public override string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Boss reference of department.
        /// </summary>
        public User Boss { get; set; }

        /// <summary>
        /// Employees that work in the department.
        /// </summary>
        public ICollection<User> Employees { get; set; } = new HashSet<User>();

        /// <summary>
        /// Is <paramref name="user"/> in this department?
        /// </summary>
        /// <param name="user">User to check</param>
        /// <returns>True if <paramref name="user"/> is in this department.</returns>
        public bool HasEmployee(User user) => EmployeeIds.Contains(user.Id);
    }
}
