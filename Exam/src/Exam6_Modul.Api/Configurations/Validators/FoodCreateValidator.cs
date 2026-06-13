using Exam6_Modul.Api.Dtos;
using FluentValidation;

namespace Exam6_Modul.Api.Configurations.Validators;

public class FoodCreateValidator : AbstractValidator<FoodCreateDto>
{
    public FoodCreateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.CategoryId).GreaterThan(0);
    }
}
