using Exam6_Modul.Api.Dtos;
using FluentValidation;

namespace Exam6_Modul.Api.Configurations.Validators;

public class FoodUpdateValidator : AbstractValidator<FoodUpdateDto>
{
    public FoodUpdateValidator()
    {
        RuleFor(x => x.Name).MaximumLength(100).When(x => x.Name != null);
        RuleFor(x => x.Price).GreaterThan(0).When(x => x.Price != null);
    }
}
