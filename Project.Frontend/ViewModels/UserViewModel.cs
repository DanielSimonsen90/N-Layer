using Project.DAL.Entities;

namespace Project.Frontend.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(IEnumerable<User> users)
        {
            Users = users;
        }
        
        public IEnumerable<User> Users { get; set; }
        public User Shell { get; set; } = new();
    }
}
