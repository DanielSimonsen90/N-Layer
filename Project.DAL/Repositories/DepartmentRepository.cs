using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.Core;
using Project.DAL.Repositories.IRepositories;

namespace Project.DAL.Repositories
{
    public class DepartmentRepository : BaseRepository<Department, string, ProjectDbContext>, IDepartmentRepository
    {
        public DepartmentRepository(ProjectDbContext context) : base(context) { }

        protected override DbSet<Department> Set => _context.Departments;

        public Department? GetByName(string name)
        {
            return Set.FirstOrDefault(d => d.Name == name);
        }

        public Department? GetWithBoss(string id)
        {
            return GetWithRelations(id, department => department.Boss);
        }

        public Department? GetWithEmployees(string id)
        {
            return GetWithRelations(id, department => department.Employees);
        }
    }
}
