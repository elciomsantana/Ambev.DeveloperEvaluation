using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.InactiveSale;

/// <summary>
/// Validator for InactiveSaleCommand
/// </summary>
public class InactiveSaleValidator : AbstractValidator<InactiveSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for InactiveSaleCommand
    /// </summary>
    public InactiveSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
