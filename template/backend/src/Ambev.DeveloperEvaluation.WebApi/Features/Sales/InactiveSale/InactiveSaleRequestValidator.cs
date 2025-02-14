using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.InactiveSale;

/// <summary>
/// Validator for InactiveSaleRequest
/// </summary>
public class InactiveSaleRequestValidator : AbstractValidator<InactiveSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for InactiveSaleRequest
    /// </summary>
    public InactiveSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
