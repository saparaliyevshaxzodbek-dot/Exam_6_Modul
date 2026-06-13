using Exam6_Modul.Api.Dtos;
using FluentValidation;

namespace Exam6_Modul.Api.Configurations.Validators;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}
