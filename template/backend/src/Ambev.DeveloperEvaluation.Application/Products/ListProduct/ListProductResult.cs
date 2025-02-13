using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Response model for ListProduct operation
/// </summary>
public class ListProductResult
{
    /// <summary>
    /// List of products
    /// </summary>
    public List<GetProductResult> ListOfProducts { get; set; } = new();

}
