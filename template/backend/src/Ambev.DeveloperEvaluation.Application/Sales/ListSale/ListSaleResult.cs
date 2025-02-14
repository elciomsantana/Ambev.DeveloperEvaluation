using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Response model for ListSale operation
/// </summary>
public class ListSaleResult
{
    /// <summary>
    /// List of Sales
    /// </summary>
    public List<GetSaleResult> ListOfSales { get; set; } = new();

}
