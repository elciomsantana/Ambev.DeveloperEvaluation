using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.InactiveSale;

/// <summary>
/// Command for deleting a Sale
/// </summary>
public record InactiveSaleCommand : IRequest<InactiveSaleResponse>
{
    /// <summary>
    /// The unique identifier of the Sale to Inactive
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of InactiveSaleCommand
    /// </summary>
    /// <param name="id">The ID of the Sale to Inactive</param>
    public InactiveSaleCommand(Guid id)
    {
        Id = id;
    }
}
