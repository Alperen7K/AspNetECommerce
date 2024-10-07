using Entities.DTO_s;
using FluentValidation;

namespace Business.ValidationRules.ValidationRules;

public class AuthValidator : AbstractValidator<UserForRegisterDto>
{
    public AuthValidator()
    {
        RuleFor(user => user.Email).NotEmpty().WithMessage("Email is required.");

        RuleFor(user => user.FirstName).NotEmpty().WithMessage("First name is required.").MinimumLength(6)
            .MaximumLength(30)
            .WithMessage("Email must be between 6 and 30 characters.");

        RuleFor(user => user.LastName).NotEmpty().WithMessage("Last name is required.").MinimumLength(6)
            .MaximumLength(30)
            .WithMessage("Email must be between 6 and 30 characters.");

        RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required.").EmailAddress()
            .WithMessage("Invalid email address.");
    }
}