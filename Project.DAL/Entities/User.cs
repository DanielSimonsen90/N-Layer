using Project.DAL.Entities.DTO;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{
    /// <summary>
    /// User entity for this project.
    /// </summary>
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

        /// <summary>
        /// Password for the user. This is not really used, but it's a user, so gotta include it
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Password { get; set; }

        /// <summary>
        /// Department the user may work in
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// The department the user may be a boss of.
        /// </summary>
        public Department? OwnedDepartment { get; set; }

        /// <summary>
        /// Check if this user is boss of <paramref name="department"/>.
        /// </summary>
        /// <param name="department">The department to check.</param>
        /// <returns>True if this is the boss of <paramref name="department"/>.</returns>
        public bool IsBossFor(Department department) => department.BossId == Id;
    }
}
