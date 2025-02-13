namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.InactiveBranch;

/// <summary>
/// Request model for deleting a Branch
/// </summary>
public class InactiveBranchRequest
{
    /// <summary>
    /// The unique identifier of the Branch to Inactive
    /// </summary>
    public Guid Id { get; set; }
}
