using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new Product in the system.
/// </summary>
public class CreateProductRequest
{
   

    /// <summary>
    /// Name of the Product
    /// </summary>
    public string Name { get; set; } = string.Empty;


    /// <summary>
    /// Product unit price
    /// </summary>
    public decimal UnitPrice { get; set; }


}