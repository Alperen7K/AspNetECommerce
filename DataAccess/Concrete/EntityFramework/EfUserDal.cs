using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, PostgreSqlContext>, IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        using (var context = new PostgreSqlContext())
        {
            var result = from operationClaim in context.UserOperationClaimes
                join userOperationClaim in context.UserOperationClaimes
                    on operationClaim.Id equals userOperationClaim.OperationClaimId
                where userOperationClaim.UserId == user.Id
                select new OperationClaim
                {
                    Id = operationClaim.Id //, Name = operationClaim.Name
                };
            return result.ToList();
        }
    }
}