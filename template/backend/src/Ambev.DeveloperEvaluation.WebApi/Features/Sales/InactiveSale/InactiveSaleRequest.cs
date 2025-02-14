namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.InactiveSale;

/// <summary>
/// Request model for deleting a Sale
/// </summary>
public class InactiveSaleRequest
{
    /// <summary>
    /// The unique identifier of the Sale to Inactive
    /// </summary>
    public Guid Id { get; set; }
}
