using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;

/// <summary>
/// API response model for GetBranch operation
/// </summary>
public class GetBranchResponse
{
    /// <summary>
    /// The unique identifier of the Branch
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the Branch
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Created date of the Branch
    /// </summary>
    public DateTime CreatedDate { get; set; }

}
