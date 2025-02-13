using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

/// <summary>
/// API response model for ListProduct operation
/// </summary>
public class ListProductResponse
{

    /// <summary>
    /// List of Products
    /// </summary>
    public GetProductResponse[] ListOfProducts { get; set; }

}
