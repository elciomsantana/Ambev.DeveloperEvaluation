using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {

    //    RuleFor(Sale => Sale.SaleItems)
       //     .NotEmpty()
      //      .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
      //      .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");

    }
}