using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Model;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new Sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// The unique identifier of the customer (User Role=1)
    /// </summary>
    [JsonIgnore]
    public Guid CustomerId { get; set; }

    /// <summary>
    /// The unique identifier of the branch 
    /// </summary>
    public Guid BranchId { get;  set; }

    /// <summary>
    /// List of sale items
    /// </summary>
    public List<SaleItemModel> SaleItems { get; set; } = new();

  
}
