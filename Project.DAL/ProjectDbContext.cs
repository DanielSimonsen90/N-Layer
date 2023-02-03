using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
    
namespace Project.DAL
{
    /// <summary>
    /// The DbContext of the project. This is also called ApplicationDbContext.
    /// </summary>
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext() {}
        public ProjectDbContext(DbContextOptions options) : base(options) {}
        
        /// <summary>
        /// Users in the database
        /// </summary>
        public DbSet<User> Users { get; set; }
        
        /// <summary>
        /// Departments in the database
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define relationships between entities.
            builder.Entity<Department>()
                .HasOne(d => d.Boss)
                .WithOne(u => u.OwnedDepartment)
                .HasForeignKey<Department>(d => d.BossId);

            builder.Entity<User>()
                .HasOne(u => u.Department);
            builder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(u => u.Department)
                .HasForeignKey(u => u.DepartmentId);
            
            
        }
    }
}
