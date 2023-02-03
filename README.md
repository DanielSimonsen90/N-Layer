# N-Layer Concept

## Projects
* Core
    - This project is only abstract. This includes BaseUnitOfWork, BaseRepository, EntityNotFoundException & IEntity.
    This can be used in *any* project using the N-Layer structure.

* DAL
    - This project includes entities, repositories, DbContext & UoW.

* BLL
    - Layer for service definitions, and demo related UserAlreadyInDepartmentException.

* Frontend
    - Project to test the layering system as a demo. Domain is hiring users into departments and having a user to be a "boss" of a department.