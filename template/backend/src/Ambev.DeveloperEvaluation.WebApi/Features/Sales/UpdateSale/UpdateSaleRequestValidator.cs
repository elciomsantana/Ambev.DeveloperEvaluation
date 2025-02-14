using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleRequest that defines validation rules for Sale creation.
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be valid format (using EmailValidator)
    /// - Salename: Required, length between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be Unknown
    /// - Role: Cannot be None
    /// </remarks>
    public UpdateSaleRequestValidator()
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
