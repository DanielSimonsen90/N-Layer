using Project.Core;
using Project.DAL.Repositories;

namespace Project.DAL
{
    public class UnitOfWork : BaseUnitOfWork<ProjectDbContext>
    {
        public UnitOfWork(ProjectDbContext context) : base(context)
        {
            Users = new(Context);
            Departments = new(Context);
        }

        public UserRepository Users { get; set; }
        public DepartmentRepository Departments { get; set; }
    }
}
