using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, PostgreSqlContext>, IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        throw new NotImplementedException();
    }
}