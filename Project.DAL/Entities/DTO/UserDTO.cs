using Project.Core;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities.DTO
{
    /// <summary>
    /// DTO object for <see cref="User"/>.
    /// This extends <see cref="BaseEntity{string}"/> to also be used as a base class for <see cref="User"/>.
    /// </summary>
    public class UserDTO : BaseEntity<int>
    {
        /// <summary>.
        /// Convert <see cref="User"/> to <see cref="UserDTO"/>
        /// </summary>
        /// <param name="user">Department to convert to DTO.</param>
        /// <returns>DTO object of <paramref name="user"/>.</returns>
        public static UserDTO Convert(User user)
        {
            return new UserDTO(user.Username, user.Email, user.Department);
        }

#nullable disable
        public UserDTO() {}
#nullable enable
        public UserDTO(string username, string? email, Department? department)
        {
            Username = username;
            Email = email;
            DepartmentId = department?.Id;
        }

        /// <summary>
        /// Name of the user
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Username { get; set; }

        /// <summary>
        /// Email of the user
        /// </summary>
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// Id of the department they work for
        /// </summary>
        public string? DepartmentId { get; set; }
    }
}
