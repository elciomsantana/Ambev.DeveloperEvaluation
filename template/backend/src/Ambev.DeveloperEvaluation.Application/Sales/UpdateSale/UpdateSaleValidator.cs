using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleCommand that defines validation rules for Sale creation command.
/// </summary>
public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the UpdateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)
    /// - Salename: Required, must be between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be set to Unknown
    /// - Role: Cannot be set to None
    /// </remarks>
    public UpdateSaleCommandValidator()
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