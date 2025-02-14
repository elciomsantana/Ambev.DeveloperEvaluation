using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    /// <summary>
    /// Validation of Sale item
    /// </summary>
    public SaleItemValidator()
    {
        RuleFor(x => x.SaleId)
           .NotEmpty()
           .WithMessage("Sale ID is required");
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product ID is required");
        RuleFor(x => x.Quantity)
           .NotEmpty().GreaterThanOrEqualTo(0)
           .WithMessage("Quantity must be greater than or equals 0.");
    }
}