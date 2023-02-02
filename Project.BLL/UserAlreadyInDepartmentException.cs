using Project.DAL.Entities;

namespace Project.BLL
{
    internal class UserAlreadyInDepartmentException : Exception
    {
        public UserAlreadyInDepartmentException(User user, Department department)
            : base($"User {user.Username} is already in department {department.Name}.")
        {
            User = user;
            Department = department;
        }

        public User User { get; set; }
        public Department Department { get; set; }
    }
}
