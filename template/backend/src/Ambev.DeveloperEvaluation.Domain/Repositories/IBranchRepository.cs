using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Branch entity operations
/// </summary>
public interface IBranchRepository
{
    /// <summary>
    /// Creates a new Branch in the repository
    /// </summary>
    /// <param name="Branch">The Branch to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Branch</returns>
    Task<Branch> CreateAsync(Branch Branch, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a Branch by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Branch</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Branch if found, null otherwise</returns>
    Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Inactive a Branch by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Branch</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Branch if found, null otherwise</returns>
    Task<bool> InactiveAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a List Branch 
    /// </summary>
    /// <returns>The List of Branch if found, null otherwise</returns>
    Task<Branch[]> ListAsync(CancellationToken cancellationToken = default);

}
