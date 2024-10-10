using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTO_s;

namespace DataAccess.Abstract;

public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
{
    public List<UserOperationClaimDetailDto> GetUserOperationClaimsByUserId(int id);
}