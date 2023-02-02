using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
    
namespace Project.DAL
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
