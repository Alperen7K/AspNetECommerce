using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserDal : IEntityRepository<User>
{
    List<User> GetAllUser();

    User GetUserById(int userId);

    Boolean AddUser(User user);

    Boolean UpdateUser(User user);

    Boolean DeleteUser(User user);
}