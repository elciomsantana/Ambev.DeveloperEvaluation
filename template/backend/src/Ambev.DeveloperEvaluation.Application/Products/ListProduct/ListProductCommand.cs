using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Command for list Products
/// </summary>
public record ListProductCommand : IRequest<ListProductResult>
{
    
    /// <summary>
    /// Initializes a new instance of ListProductCommand
    /// </summary>    
    public ListProductCommand()
    {
      
    }
}
