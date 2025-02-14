using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Model;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity operations
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Creates a new Sale in the repository
    /// </summary>
    /// <param name="Sale">The Sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Sale</returns>
    Task<Sale> CreateAsync(SaleModel Sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a Sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Sale if found, null otherwise</returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Inactive a Sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Sale if found, null otherwise</returns>
    Task<bool> InactiveAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a List Sale 
    /// </summary>
    /// <returns>The List of Sale if found, null otherwise</returns>
    Task<Sale[]> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update products quantity of the sale.
    /// </summary>
    /// <returns>The List of Sale if found, null otherwise</returns>
    Task<Sale> UpdateAsync(UpdateSaleModel saleRequest, CancellationToken cancellationToken = default);

}
