using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Response model for GetProduct operation
/// </summary>
public class GetProductResult
{
    /// <summary>
    /// The unique identifier of the Prodduct
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the Product
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Created date of the Product
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Product unit price
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Inactivated date of the Product
    /// </summary>
    public DateTime? InactivatedDate { get;  set; }


}
