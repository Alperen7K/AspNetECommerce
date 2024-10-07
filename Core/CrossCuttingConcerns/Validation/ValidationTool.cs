using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation;

public class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        var context = new ValidationContext<object>(entity);
        var result = validator.Validate(context);
        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                throw new ValidationException(error.ErrorMessage);
            }
        }
    }
}