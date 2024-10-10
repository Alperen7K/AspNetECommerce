using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTO_s;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, PostgreSqlContext>,
    IUserOperationClaimDal
{
    public List<UserOperationClaimDetailDto> GetUserOperationClaimsByUserId(int id)
    {
        using (var context = new PostgreSqlContext())
        {
            var result = from userOperationClaim in context.UserOperationClaims
                join operationClaim in context.OperationClaims
                    on userOperationClaim.OperationClaimId equals operationClaim.Id
                where userOperationClaim.UserId == id
                select new UserOperationClaimDetailDto
                    { OperationClaimId = operationClaim.Id, OperationClaimName = operationClaim.Name };
            return result.ToList();
        }
    }
}