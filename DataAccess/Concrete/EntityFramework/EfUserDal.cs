using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, PostgreSqlContext>, IUserDal
{
    public List<User> GetAllUser()
    {
        throw new NotImplementedException();
    }

    public User GetUserById(int userId)
    {
        throw new NotImplementedException();
    }

    public bool AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public bool UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public bool DeleteUser(User user)
    {
        throw new NotImplementedException();
    }
}