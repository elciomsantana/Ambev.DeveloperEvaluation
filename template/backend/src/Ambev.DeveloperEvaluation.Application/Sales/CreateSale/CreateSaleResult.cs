using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents the response returned after successfully creating a new Sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created Sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateSaleResult
{
    /// <summary>
    /// The unique identifier of the sale 
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Created date of the sale item
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// The unique identifier of the customer (User Role=1)
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// The unique identifier of the branch 
    /// </summary>
    public Guid BranchId { get; private set; }

    /// <summary>
    /// Canceled date of the sale 
    /// </summary>
    public DateTime? CanceledDate { get; set; }

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
