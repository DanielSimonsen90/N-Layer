using Project.Core;
using Project.DAL.Entities;
using Project.DAL.Repositories;

namespace Project.DAL
{
    /// <summary>
    /// Unit of work for the database.
    /// Extends <see cref="BaseUnitOfWork{TDbContext}"/> with <see cref="ProjectDbContext"/>
    /// </summary>
    public class UnitOfWork : BaseUnitOfWork<ProjectDbContext>
    {
        public UnitOfWork(ProjectDbContext context) : base(context)
        {
            Users = new(Context);
            Departments = new(Context);
        }

        /// <summary>
        /// Repository for the <see cref="User"/> model.
        /// </summary>
        public UserRepository Users { get; set; }
        /// <summary>
        /// Repository for the <see cref="Department"/> model.
        /// </summary>
        public DepartmentRepository Departments { get; set; }
    }
}
