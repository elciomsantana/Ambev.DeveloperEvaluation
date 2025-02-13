using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.InactiveProduct;

/// <summary>
/// Command for deleting a Product
/// </summary>
public record InactiveProductCommand : IRequest<InactiveProductResponse>
{
    /// <summary>
    /// The unique identifier of the Product to Inactive
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of InactiveProductCommand
    /// </summary>
    /// <param name="id">The ID of the Product to Inactive</param>
    public InactiveProductCommand(Guid id)
    {
        Id = id;
    }
}
