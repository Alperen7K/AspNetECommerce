using Business.ValidationRules.FluentValidation.Auth;
using Entities.DTO_s;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class MultipleUserOperationClaimValidator : AbstractValidator<AddUserOperationClaimDto>
{
    public MultipleUserOperationClaimValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("UserId cannot be empty");

        RuleFor(p => p.OperationClaimIds).NotEmpty().WithMessage("OperationClaimId cannot be empty");
    }
}