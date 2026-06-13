using Exam6_Modul.Api.Dtos;
using FluentValidation;

namespace Exam6_Modul.Api.Configurations.Validators;

public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateValidator()
    {
        RuleFor(x => x.Name).MaximumLength(50).When(x => x.Name != null);
    }
}
