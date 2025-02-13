namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.ListBranch;

/// <summary>
/// Request model for getting a Branch by ID
/// </summary>
public class ListBranchRequest
{
    /// <summary>
    /// The unique identifier of the Branch to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
