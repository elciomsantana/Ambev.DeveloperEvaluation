using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.InactiveProduct;

/// <summary>
/// Validator for InactiveProductCommand
/// </summary>
public class InactiveProductValidator : AbstractValidator<InactiveProductCommand>
{
    /// <summary>
    /// Initializes validation rules for InactiveProductCommand
    /// </summary>
    public InactiveProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required");
    }
}
