using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

/// <summary>
/// API response model for CreateBranch operation
/// </summary>
public class CreateBranchResponse
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
