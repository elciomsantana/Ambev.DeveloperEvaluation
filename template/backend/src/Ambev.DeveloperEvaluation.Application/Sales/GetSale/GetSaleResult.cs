using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
{
    /// <summary>
    /// The unique identifier of the sale 
    /// </summary>
    public Guid Id { get;  set; }

    /// <summary>
    /// Created date of the sale item
    /// </summary>
    public DateTime CreatedDate { get;  set; }

    /// <summary>
    /// The unique identifier of the customer (User Role=1)
    /// </summary>
    public Guid CustomerId { get;  set; }

    /// <summary>
    /// The unique identifier of the branch 
    /// </summary>
    public Guid BranchId { get; private set; }

    /// <summary>
    /// Canceled date of the sale 
    /// </summary>
    public DateTime? CanceledDate { get;  set; }

    /// <summary>
    /// List of sale items
    /// </summary>
    public IReadOnlyCollection<SaleItem>? SaleItems { get; set; } 

    /// <summary>
    /// Total of sale item price without discount
    /// </summary>
    public decimal TotalWithoutDiscount { get; set; }

    /// <summary>
    /// Total Discount of the sale 
    /// </summary>
    public decimal TotalDiscount { get; set; }

    /// <summary>
    /// Total of sale item price with discount
    /// </summary>
    public decimal TotalWithDiscount { get; set; }



}
