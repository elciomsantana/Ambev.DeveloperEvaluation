using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// API response model for ListSale operation
/// </summary>
public class ListSaleResponse
{

    /// <summary>
    /// Sale list of user
    /// </summary>
    public GetSaleResponse[] ListOfSales { get; set; }

  

}
