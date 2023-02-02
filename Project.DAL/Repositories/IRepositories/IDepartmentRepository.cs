using Project.DAL.Entities;

namespace Project.DAL.Repositories.IRepositories
{
    public interface IDepartmentRepository
    {
        Department? GetByName(string name);
        Department? GetWithBoss(string id);
        Department? GetWithEmployees(string id);
    }
}
