using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.Core;
using Project.DAL.Repositories.IRepositories;

namespace Project.DAL.Repositories
{
    public class UserRepository : BaseRepository<User, int, ProjectDbContext>, IUserRepository
    {
        public UserRepository(ProjectDbContext context) : base(context) {}

        protected override DbSet<User> Set => _context.Users;

        public override bool Add(User entity)
        {
            // Validation

            return base.Add(entity);
        }
        public User? GetByUsername(string username)
        {
            return Set.FirstOrDefault(u => u.Username == username);
        }

        public User? GetWithDepartment(int id)
        {
            return GetWithRelations(id, user => user.Department);
        }
    }
}
