using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.Core;
using Project.DAL.Repositories.IRepositories;

namespace Project.DAL.Repositories
{
    /// <summary>
    /// Repository for <see cref="Department"/> entities.
    /// </summary>
    public class DepartmentRepository : BaseRepository<Department, string, ProjectDbContext>, IDepartmentRepository
    {
        public DepartmentRepository(ProjectDbContext context) : base(context) { }

        // Set the reference to ProjectDbContext.Departments.
        protected override DbSet<Department> Set => _context.Departments;

        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">If boss found from <paramref name="entity"/> is null.</exception>
        public override bool Add(Department entity)
        {
            if (!base.Add(entity)) return false;

            User? boss = _context.Users.Find(entity.BossId);
            if (boss is null) throw new InvalidOperationException("Boss should not be null");

            boss.Department = null;
            boss.DepartmentId = null;
            return true;
        }

        public Department? GetByName(string name) => Set.FirstOrDefault(d => d.Name == name);
        public Department? GetWithBoss(string id) => GetWithRelations(id, department => department.Boss);
        public Department? GetWithEmployees(string id) => GetWithRelations(id, department => department.Employees);
    }
}
