using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.Core;
using Project.DAL.Repositories.IRepositories;

namespace Project.DAL.Repositories
{
    /// <summary>
    /// Repository for <see cref="User"/> entities.
    /// </summary>
    public class UserRepository : BaseRepository<User, int, ProjectDbContext>, IUserRepository
    {
        public UserRepository(ProjectDbContext context) : base(context) {}

        // Set the reference to ProjectDbContext.Users.
        protected override DbSet<User> Set => _context.Users;

        public IEnumerable<User> GetUsersNotInDepartment(Department department) => GetAll().Where(user => 
            user.DepartmentId != department.Id 
            && user.OwnedDepartment?.Id != department.Id);
        public User? GetByUsername(string username) => Set.FirstOrDefault(u => u.Username == username);

        public User? GetWithDepartment(int id) => GetWithRelations(id, user => user.Department);
    }
}
