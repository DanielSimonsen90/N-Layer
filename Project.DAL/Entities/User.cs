using Project.DAL.Entities.DTO;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{
    public class User : UserDTO
    {
#nullable disable
        public User() {}
#nullable enable

        public User(string username, string password, string? email, Department? department)
            : base(username, email, department)
        {
            Username = username;
            Password = password;
            Email = email;
            Department = department;
        }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Password { get; set; }

        public Department? Department { get; set; }
        public Department? OwnedDepartment { get; set; }

        public bool IsBossFor(Department department) => department.BossId == Id;
    }
}
