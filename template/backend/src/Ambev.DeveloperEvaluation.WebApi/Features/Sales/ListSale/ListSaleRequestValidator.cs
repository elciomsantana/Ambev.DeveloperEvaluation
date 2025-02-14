using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Validator for ListSaleRequest
/// </summary>
public class ListSaleRequestValidator : AbstractValidator<ListSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for ListSaleRequest
    /// </summary>
    public ListSaleRequestValidator()
    {
      //Filters validation
    }
}
