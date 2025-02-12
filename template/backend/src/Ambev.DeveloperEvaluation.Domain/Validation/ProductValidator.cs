using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {

        RuleFor(Product => Product.Name)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");


        RuleFor(Product => Product.UnitPrice)
            .GreaterThan(0)
            .WithMessage("Product unit price must be greater than U$ 0.");
    }
}