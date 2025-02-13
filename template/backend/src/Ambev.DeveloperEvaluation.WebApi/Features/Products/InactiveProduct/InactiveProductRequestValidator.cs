using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.InactiveProduct;

/// <summary>
/// Validator for InactiveProductRequest
/// </summary>
public class InactiveProductRequestValidator : AbstractValidator<InactiveProductRequest>
{
    /// <summary>
    /// Initializes validation rules for InactiveProductRequest
    /// </summary>
    public InactiveProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required");
    }
}
