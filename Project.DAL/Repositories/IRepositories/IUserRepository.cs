using Project.DAL.Entities;

namespace Project.DAL.Repositories.IRepositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        User? GetWithDepartment(int id);
    }
}
