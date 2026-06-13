using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Exam6_Modul.Api.Configurations;

public class ValidationFilter : IAsyncActionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public ValidationFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        foreach (var arg in context.ActionArguments)
        {
            var value = arg.Value;
            if (value is null) continue;

            var validatorType = typeof(IValidator<>).MakeGenericType(value.GetType());
            var validator = _serviceProvider.GetService(validatorType) as IValidator;
            if (validator is null) continue;

            var validationContext = new FluentValidation.ValidationContext<object>(value);
            var result = await validator.ValidateAsync(validationContext);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    context.ModelState.AddModelError(error.PropertyName ?? arg.Key, error.ErrorMessage);
                }
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
        }

        await next();
    }
}
