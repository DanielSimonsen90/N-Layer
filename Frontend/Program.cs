using Project.BLL;
using Project.DAL;
using Project.DAL.Entities;

User user = new();

UserService userService = new();
//userService.Insert(user);

UnitOfWork uow = new();
uow.Users.Add(user);
