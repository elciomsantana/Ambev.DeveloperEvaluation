using Ambev.DeveloperEvaluation.Domain.Enums;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Represents a request to Update a new Sale in the system.
/// </summary>
public class UpdateSaleRequest
{
    
    /// <summary>
    /// The unique identifier of the Customer
    /// </summary>
    [JsonIgnore]
    public Guid CustomerId { get; set; }

    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// The unique identifier of the Prodduct
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The Quantity of the product
    /// </summary>
    public int Quantity { get; set; }



}