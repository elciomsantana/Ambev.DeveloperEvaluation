namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.InactiveProduct;

/// <summary>
/// Request model for deleting a Product
/// </summary>
public class InactiveProductRequest
{
    /// <summary>
    /// The unique identifier of the Product to Inactive
    /// </summary>
    public Guid Id { get; set; }
}
