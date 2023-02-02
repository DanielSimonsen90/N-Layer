using Project.Core;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities.DTO
{
    public class UserDTO : BaseEntity<int>
    {
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

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? DepartmentId { get; set; }
    }
}
