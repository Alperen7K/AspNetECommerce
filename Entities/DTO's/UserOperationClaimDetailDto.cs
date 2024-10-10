using Core.Entities;

namespace Entities.DTO_s;

public class UserOperationClaimDetailDto : IDto
{
    public int OperationClaimId { get; set; }
    public string OperationClaimName { get; set; }
}