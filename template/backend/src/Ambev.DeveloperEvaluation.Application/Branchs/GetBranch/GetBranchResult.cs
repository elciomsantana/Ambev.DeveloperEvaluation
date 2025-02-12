using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

/// <summary>
/// Response model for GetBranch operation
/// </summary>
public class GetBranchResult
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

    /// <summary>
    /// Inactivated  date of the Branch
    /// </summary>
    public DateTime? InactivatedDate { get; private set; }



}
